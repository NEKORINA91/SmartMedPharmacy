using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using SmartMedPharmacy.DAL;

namespace SmartMedPharmacy.Forms
{
    public partial class ReportsForm : Form
    {
        private readonly ReportsDAL _reportsDAL = new ReportsDAL();

        // Store the current report data as plain object lists so we can
        // pass them to either the PDF or Excel exporter without re-querying
        private List<SalesReportRow> _salesData;
        private List<StockReportRow> _stockData;
        private List<OrderHistoryRow> _historyData;
        private string _currentReportType = "";

        public ReportsForm()
        {
            InitializeComponent();
            cmbReportType.SelectedIndex = 0;
        }

        // ===================== LOAD REPORT =====================

        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            string selected = cmbReportType.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selected))
                return;

            try
            {
                _salesData = null;
                _stockData = null;
                _historyData = null;

                switch (selected)
                {
                    case "Sales Report":
                        _salesData = _reportsDAL.GetSalesReport();
                        dgvReport.DataSource = _salesData;
                        _currentReportType = "Sales";
                        break;

                    case "Stock Report":
                        _stockData = _reportsDAL.GetStockReport();
                        dgvReport.DataSource = _stockData;
                        _currentReportType = "Stock";
                        break;

                    case "Customer Order History":
                        _historyData = _reportsDAL.GetOrderHistoryReport();
                        dgvReport.DataSource = _historyData;
                        _currentReportType = "OrderHistory";
                        break;
                }

                lblReportTitle.Text = selected + " — " + DateTime.Now.ToString("dd MMM yyyy");
                btnExportPDF.Enabled = true;
                btnExportExcel.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not generate report.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===================== PDF EXPORT =====================

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf",
                FileName = _currentReportType + "_Report_" + DateTime.Now.ToString("yyyyMMdd") + ".pdf",
                Title = "Save PDF Report"
            };

            if (saveDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                using (PdfWriter writer = new PdfWriter(saveDialog.FileName))
                using (PdfDocument pdf = new PdfDocument(writer))
                using (Document doc = new Document(pdf))
                {
                    // Title
                    doc.Add(new Paragraph("SmartMed Pharmacy")
                        .SetFontSize(18)
                        .SetFont(iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD))
                        .SetTextAlignment(TextAlignment.CENTER));

                    doc.Add(new Paragraph(lblReportTitle.Text)
                        .SetFontSize(13)
                        .SetTextAlignment(TextAlignment.CENTER));

                    doc.Add(new Paragraph("Generated: " + DateTime.Now.ToString("dd MMM yyyy, hh:mm tt"))
                        .SetFontSize(9)
                        .SetTextAlignment(TextAlignment.CENTER));

                    doc.Add(new Paragraph("\n"));

                    // Table
                    Table table = BuildPdfTable();
                    doc.Add(table);
                }

                MessageBox.Show("PDF saved successfully!\n\n" + saveDialog.FileName,
                    "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                System.Diagnostics.Process.Start(saveDialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not export PDF.\n\n" + ex.Message,
                    "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Table BuildPdfTable()
        {
            switch (_currentReportType)
            {
                case "Sales":
                    var salesTable = new Table(new float[] { 1, 3, 2, 2, 2 })
                        .UseAllAvailableWidth();
                    AddPdfHeader(salesTable, new[] { "Order #", "Customer", "Date", "Status", "Total (Rs.)" });
                    foreach (var row in _salesData)
                    {
                        salesTable.AddCell(row.OrderId.ToString());
                        salesTable.AddCell(row.CustomerName);
                        salesTable.AddCell(row.OrderDate);
                        salesTable.AddCell(row.Status);
                        salesTable.AddCell(row.TotalAmount.ToString("N2"));
                    }
                    return salesTable;

                case "Stock":
                    var stockTable = new Table(new float[] { 3, 2, 1, 1, 1, 2 })
                        .UseAllAvailableWidth();
                    AddPdfHeader(stockTable, new[] { "Name", "Category", "Dosage", "Price", "Stock", "Supplier" });
                    foreach (var row in _stockData)
                    {
                        stockTable.AddCell(row.Name);
                        stockTable.AddCell(row.Category);
                        stockTable.AddCell(row.Dosage);
                        stockTable.AddCell(row.Price.ToString("N2"));
                        stockTable.AddCell(row.StockQuantity.ToString());
                        stockTable.AddCell(row.Supplier);
                    }
                    return stockTable;

                case "OrderHistory":
                    var historyTable = new Table(new float[] { 3, 2, 1, 2 })
                        .UseAllAvailableWidth();
                    AddPdfHeader(historyTable, new[] { "Customer", "Username", "Orders", "Total Spent (Rs.)" });
                    foreach (var row in _historyData)
                    {
                        historyTable.AddCell(row.CustomerName);
                        historyTable.AddCell(row.Username);
                        historyTable.AddCell(row.TotalOrders.ToString());
                        historyTable.AddCell(row.TotalSpent.ToString("N2"));
                    }
                    return historyTable;

                default:
                    return new Table(1);
            }
        }

        private void AddPdfHeader(Table table, string[] headers)
        {
            var boldFont = iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);
            foreach (var header in headers)
            {
                table.AddHeaderCell(new Cell()
                    .Add(new Paragraph(header).SetFont(boldFont))
                    .SetBackgroundColor(iText.Kernel.Colors.ColorConstants.LIGHT_GRAY));
            }
        }

        // ===================== EXCEL EXPORT =====================

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                FileName = _currentReportType + "_Report_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx",
                Title = "Save Excel Report"
            };

            if (saveDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add(_currentReportType + " Report");

                    // Title rows
                    worksheet.Cell(1, 1).Value = "SmartMed Pharmacy";
                    worksheet.Cell(1, 1).Style.Font.Bold = true;
                    worksheet.Cell(1, 1).Style.Font.FontSize = 16;

                    worksheet.Cell(2, 1).Value = lblReportTitle.Text;
                    worksheet.Cell(3, 1).Value = "Generated: " + DateTime.Now.ToString("dd MMM yyyy, hh:mm tt");

                    int dataStartRow = 5;

                    switch (_currentReportType)
                    {
                        case "Sales":
                            string[] salesHeaders = { "Order #", "Customer", "Date", "Status", "Total (Rs.)" };
                            WriteExcelHeaders(worksheet, dataStartRow, salesHeaders);
                            int salesRow = dataStartRow + 1;
                            foreach (var row in _salesData)
                            {
                                worksheet.Cell(salesRow, 1).Value = row.OrderId;
                                worksheet.Cell(salesRow, 2).Value = row.CustomerName;
                                worksheet.Cell(salesRow, 3).Value = row.OrderDate;
                                worksheet.Cell(salesRow, 4).Value = row.Status;
                                worksheet.Cell(salesRow, 5).Value = row.TotalAmount;
                                salesRow++;
                            }
                            break;

                        case "Stock":
                            string[] stockHeaders = { "Name", "Category", "Dosage", "Price (Rs.)", "Stock Qty", "Supplier" };
                            WriteExcelHeaders(worksheet, dataStartRow, stockHeaders);
                            int stockRow = dataStartRow + 1;
                            foreach (var row in _stockData)
                            {
                                worksheet.Cell(stockRow, 1).Value = row.Name;
                                worksheet.Cell(stockRow, 2).Value = row.Category;
                                worksheet.Cell(stockRow, 3).Value = row.Dosage;
                                worksheet.Cell(stockRow, 4).Value = row.Price;
                                worksheet.Cell(stockRow, 5).Value = row.StockQuantity;
                                worksheet.Cell(stockRow, 6).Value = row.Supplier;
                                stockRow++;
                            }
                            break;

                        case "OrderHistory":
                            string[] histHeaders = { "Customer", "Username", "Total Orders", "Total Spent (Rs.)" };
                            WriteExcelHeaders(worksheet, dataStartRow, histHeaders);
                            int histRow = dataStartRow + 1;
                            foreach (var row in _historyData)
                            {
                                worksheet.Cell(histRow, 1).Value = row.CustomerName;
                                worksheet.Cell(histRow, 2).Value = row.Username;
                                worksheet.Cell(histRow, 3).Value = row.TotalOrders;
                                worksheet.Cell(histRow, 4).Value = row.TotalSpent;
                                histRow++;
                            }
                            break;
                    }

                    worksheet.Columns().AdjustToContents();
                    workbook.SaveAs(saveDialog.FileName);
                }

                MessageBox.Show("Excel file saved successfully!\n\n" + saveDialog.FileName,
                    "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                System.Diagnostics.Process.Start(saveDialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not export Excel file.\n\n" + ex.Message,
                    "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WriteExcelHeaders(IXLWorksheet worksheet, int row, string[] headers)
        {
            for (int i = 0; i < headers.Length; i++)
            {
                var cell = worksheet.Cell(row, i + 1);
                cell.Value = headers[i];
                cell.Style.Font.Bold = true;
                cell.Style.Fill.BackgroundColor = XLColor.LightGray;
            }
        }

       
    }
}
