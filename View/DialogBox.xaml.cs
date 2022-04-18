using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Hangman.View
{
    public partial class DialogBox : Window
    {
        public DialogBox()
        {
            InitializeComponent();
        }

        public List<string> GetResponseTexts()
        {
            IEnumerable<TextBox> textBoxes = mainGrid.Children.OfType<TextBox>();
            List<string> response = new List<string>();

            foreach (TextBox textBox in textBoxes)
            {
                response.Add(textBox.Text);
            }

            return response;
        }

        public void CreateDialogBox(List<string> values)
        {
            dialogBoxWindow.Height = (values.Count * 2 * 25) + 75;
            int index = 1;
            foreach (string val in values)
            {
                TextBlock textBlock = new TextBlock
                {
                    Text = val,
                    Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00)),
                    FontSize = 15
                };

                mainGrid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

                TextBox textBox = new TextBox
                {
                    Height = 25,
                    FontSize = 15,
                    TextAlignment = TextAlignment.Center
                };

                mainGrid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
                Grid.SetRow(textBlock, index++);
                mainGrid.Children.Add(textBlock);
                Grid.SetRow(textBox, index++);
                mainGrid.Children.Add(textBox);
            }
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            dialogBoxWindow.Close();
        }
    }
}