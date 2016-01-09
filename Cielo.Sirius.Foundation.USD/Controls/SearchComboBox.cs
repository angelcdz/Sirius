using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cielo.Sirius.Foundation.USD.Controls
{
    public class SearchComboBox : ComboBox
    {
        public string SearchText
        {
            get { return (string)GetValue(SearchTextProperty); }
            set { SetValue(SearchTextProperty, value); }
        }

        public static readonly DependencyProperty SearchTextProperty =
            DependencyProperty.Register("SearchText", typeof(string), typeof(SearchComboBox), new PropertyMetadata(string.Empty));

        private TextBox _searchTextBox;
        protected TextBox SearchTextBox
        {
            get
            {
                if (_searchTextBox == null)
                {
                    _searchTextBox = ((TextBox)base.GetTemplateChild("PART_SearchTextBox"));
                }
                return _searchTextBox;
            }
        }

        public SearchComboBox()
        {
            this.Loaded += SearchComboBox_Loaded;
        }

        private void SearchComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (SearchTextBox != null)
            {
                SearchTextBox.TextChanged += SearchTextBox_TextChanged;
                SearchTextBox.PreviewKeyDown += SearchTextBox_PreviewKeyDown;
            }
        }

        private void SearchTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                ((TextBox)sender).MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                e.Handled = true;
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var selectedItem = this.SelectedItem;
            Items.Filter = new Predicate<object>(FilterPredicate);
            this.SelectedItem = selectedItem;
        }

        private bool FilterPredicate(object obj)
        {
            if (obj == null) return false;
            if (string.IsNullOrWhiteSpace(SearchTextBox.Text)) return true;

            var searchTexts = RemoveDiacritics(SearchTextBox.Text).ToLower().Split(' ');
            var txtItem = RemoveDiacritics(obj.ToString()).ToLower();

            // Check if exists any text that does not exist in the itens or if the item is already selected
            return !searchTexts.Any(txt => { return !txtItem.Contains(txt); }) || SelectedItem == obj;
        }

        private string RemoveDiacritics(string text)
        {
            return string.Concat(
                text.Normalize(NormalizationForm.FormD)
                .Where(ch => CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
              ).Normalize(NormalizationForm.FormC);
        }
    }
}
