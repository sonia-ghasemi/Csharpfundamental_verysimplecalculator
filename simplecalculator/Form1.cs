
namespace simplecalculator
{
    /// <summary>
    /// یک ماشین حساب ساده که تنها چهار عمل اصلی را انجام می دهد
    /// </summary>
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //را برای ذخیره نتایج محاسبات double را از نوع result متغیر
        //را برای ذخیره عملگر بکار گرفته  operatorstring  و متغیر
        //شده توسط کاربر تعریف می کنیم

        double result = 0;
        string operatorString = "";

        //را به عنوان تابع رویداد کلیک دکمه های ارقام متصل میکنیم NumberButton_click تابع
        //اضافه شود monitorlable هر دکمه به text تا با کلیک کاربر بر روی دکمه ها رقم
        //و عدد مورد نظر کاربر در آن نمایش داده شود

        private void NumberButton_Click(object sender, System.EventArgs e)
        {
            //باقی می ماند monitorlable چون بعد از زدن دکمه مساوی نتیجه محاسبات در
            //ارقام عدد جدید در ادامه ارقام نتیجه قبلی اضافه می شود
            //به همین دلیل شرایط عملگر مساوی را جدا می کنیم
            //را برای وارد کردن عدد جدید و  monitorlable که
            //خالی می کند result را برای ذخیره عدد جدید در متغیر operatorString

            if (operatorString == "equalButton")
            {
                monitorLabel.Text = "";
                operatorString = "";
            }

            System.Windows.Forms.Button currentButten = (System.Windows.Forms.Button)sender;
            monitorLabel.Text = monitorLabel.Text + currentButten.Text;
        }

        //را بخ دکمه های عملگرها متصل میکنیم OperatorButton_click تابع
        //تا بازدن هر دکمه عملگر مربوطه بر روی اعداد اعمال شود
        //ذخیره شود resualt و نتیجه آن در متغیر
        //عملگرها بر روی عملوند دوم اعمال می شوند در نتیجه می بایستی 
        //عملوند اول و عملوند مربوطه تا ورود عملوند دوم توسط کاربر
        //ذخیره شوند oeratorString و result بعدی به ترتیب در متغیرهای operatorButton و زدن دکمه

        private void OperatorButton_Click(object sender, System.EventArgs e)
        {
            System.Windows.Forms.Button currentOperatorButton = (System.Windows.Forms.Button)sender;

            // اعمال نمی شوند monitorlabel عملگرها بدون عدد در
            //که عدد را منفی می کند minusButton بجز عملگر

            if (monitorLabel.Text != "")
            {
                //operatorString null اولین عدد قبل از اولین عملوند که یا بعد از
                //نمی شود switch های case ویا بعد از عملوند انتصاب اتفاق می افتد وارد هیچ کدام از
                //ذخیره آن را در متغیر result به صورت یک شرط جدا میکنیم

                if (operatorString == "" || operatorString == "equalButton")
                {
                    result = System.Convert.ToDouble(monitorLabel.Text);
                }

                switch (operatorString)
                {
                    case "plusButton":
                        {
                            result = result + System.Convert.ToDouble(monitorLabel.Text);
                            break;
                        }
                    case "minusButton":
                        {
                            result = result - System.Convert.ToDouble(monitorLabel.Text);
                            break;
                        }
                    case "multiplyButton":
                        {
                            result = result * System.Convert.ToDouble(monitorLabel.Text);
                            break;
                        }
                    case "devideButton":
                        {
                            if (System.Convert.ToDouble(monitorLabel.Text) != 0)
                            {
                                result = result / System.Convert.ToDouble(monitorLabel.Text);
                            }
                            if (System.Convert.ToDouble(monitorLabel.Text) == 0)
                            {
                                monitorLabel.Text = "#value";
                            }
                            break;
                        }
                }

                //برای اینکه عملگر وارد شده توسط کاربر بر عملوند بعدی خود اعمال شود و نه قبلی
                //ذخیره می کنیم operatorString در switch هر عملگر را بعد از اعمال عملوند قبلی توسط

                operatorString = currentOperatorButton.Name;

                //عملگر مساوی چون می باید نتیجه محاسبات قبل غاز خود را نشان دهد و عملوند بعدی ندارد
                //تعریف شود و می بایستی بعد از انتصاب آن switch های case نمی تواند در
                //نمایش دهد monitorLabel text را بعنوان result در یک شرط جدا متغیر operatorString به متغیر
                //نمی شود result حالت تقسیم بر صفر چون استثنا است شامل نمایش مقدار

                if (operatorString == "equalButton" && monitorLabel.Text != "#value")
                {
                    monitorLabel.Text = System.Convert.ToString(result);
                }

                //اگرحالت تقسیم بر صفر و یا عملگر مساوی نباشد بعد از سایر عملگرها می بایستی
                //را برای وارد کردن عدد بعدی آن عملوند خالی کند monitorLabel text

                else if (monitorLabel.Text != "#value")
                {
                    monitorLabel.Text = "";
                }
            }

            //شرط عملگر منها برای نمایش عملگر به عنوان علامت منفی قبل از عدد
            //monitorLabel text در حالت خالی بودن

            else if (currentOperatorButton.Name == "minusButton")
            {
                monitorLabel.Text = currentOperatorButton.Text;
            }
        }

        //CE کردن اطلاعات متغیرها به مقادیر اولیه با زدن کلید reset و monitorLabel text پاک کردن

        private void clearButton_Click(object sender, System.EventArgs e)
        {
            monitorLabel.Text = "";
            operatorString = "";
            result = 0;
        }
    }
}
