using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

public class DoubleTextBox : TextBox
{
    public DoubleTextBox()
    {
        this.KeyPress += DoubleTextBox_KeyPress;
        this.Leave += DoubleTextBox_Leave;
    }

    // Мінімальне та максимальне значення
    public double Minimum { get; set; } = double.MinValue;
    public double Maximum { get; set; } = double.MaxValue;

    // Властивість для роботи з double
    public double? Value
    {
        get
        {
            if (double.TryParse(this.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out double result))
                return result;
            return null;
        }
        set
        {
            if (value.HasValue)
            {
                // Перевірка діапазону
                if (value.Value < Minimum) value = Minimum;
                if (value.Value > Maximum) value = Maximum;

                this.Text = value.Value.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                this.Text = string.Empty;
            }
        }
    }

    private void DoubleTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar)
            && !char.IsDigit(e.KeyChar)
            && e.KeyChar != '.'
            && e.KeyChar != ',')
        {
            e.Handled = true;
        }

        if ((e.KeyChar == '.' || e.KeyChar == ',') && this.Text.Contains(e.KeyChar))
        {
            e.Handled = true;
        }
    }

    private void DoubleTextBox_Leave(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(this.Text) &&
            double.TryParse(this.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out double result))
        {
            if (result < Minimum || result > Maximum)
            {
                MessageBox.Show($"Значення має бути між {Minimum} і {Maximum}.",
                                "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Focus();
            }
        }
    }
}
