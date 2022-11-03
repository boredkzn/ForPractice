using ForPractice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Word = Microsoft.Office.Interop.Word;
using System.IO;

namespace ForPractice
{
    /// <summary>
    /// Логика взаимодействия для WindowOwner.xaml
    /// </summary>
    public partial class WindowOwner : Window
    {
        public WindowOwner()
        {
            InitializeComponent();
            var owners = new OwnerRepository().GetAll();
            OwnersDb.ItemsSource = owners;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void import_Click(object sender, RoutedEventArgs e)
        {

            var allItems = new OwnerRepository().GetAll();

            using (BaseForPracticeEntities ent = new BaseForPracticeEntities())
            {

                var app = new Word.Application();
                Word.Document document = app.Documents.Add();

                Word.Paragraph paragraph = document.Paragraphs.Add();
                Word.Range range = paragraph.Range;
                range.Text = "Таблица руководители";
                paragraph.set_Style("Заголовок 1");
                range.InsertParagraphAfter();

                Word.Paragraph tableParagraph = document.Paragraphs.Add();
                Word.Range tableRange = tableParagraph.Range;
                Word.Table studentsTable = document.Tables.Add(tableRange, allItems.Count() + 1, 3);

                studentsTable.Borders.InsideLineStyle = studentsTable.Borders.OutsideLineStyle =
                Word.WdLineStyle.wdLineStyleSingle;

                Word.Range cellRange;
                studentsTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                cellRange = studentsTable.Cell(1, 1).Range;
                cellRange.Text = "Тип";
                cellRange = studentsTable.Cell(1, 2).Range;
                cellRange.Text = "ФИО";
                cellRange = studentsTable.Cell(1, 3).Range;
                cellRange.Text = "Телефон";
                studentsTable.Rows[1].Range.Bold = 1;
                studentsTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                int i = 1;

                foreach (var cur in allItems)
                {

                    cellRange = studentsTable.Cell(i + 1, 1).Range;
                    cellRange.Text = cur.Type;
                    cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    cellRange = studentsTable.Cell(i + 1, 2).Range;
                    cellRange.Text = cur.FIO;
                    cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    cellRange = studentsTable.Cell(i + 1, 3).Range;
                    cellRange.Text = cur.Phone;
                    cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    i++;
                    app.Visible = true;

                }
                app.Visible = true;
                document.SaveAs2(@"D:\outputFilePdf.pdf", Word.WdExportFormat.wdExportFormatPDF);
            }
        }
    }
}
