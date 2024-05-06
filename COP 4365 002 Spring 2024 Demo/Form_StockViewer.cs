

///Ameya Bhujbal , U55713417, ameyabhujbal
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using System.Collections;
using WindowsFormsApp_COP_4365;



namespace COP_4365_002_Spring_2024_Demo
{
    // Defines a Form class named Form_StockViewer

    public partial class Form_StockViewer : Form
    {

        // A list to hold all Candlestick objects representing stock data

        List<smartCandlesticks> allcandlesticks= new List<smartCandlesticks>(1024);
        // A BindingList to facilitate data binding between UI controls and the list of Candlestick objects

        BindingList<smartCandlesticks> candlesticksBindingList;
        // Defines a start date initialized to January 1st, 2022, used as a default or initial value for filtering stock data.

        private DateTime startDate = new DateTime(2022, 1, 1);
        // Defines an end date initialized to the current date and time, used as the default or initial ending point for filtering stock data.

        private DateTime endDate = DateTime.Now;

        private Dictionary<string,Recognizer> patternRecognizers = new Dictionary<string,Recognizer>();

        private double chartMax;
        private double chartMin;


        /// <summary>
        ///     // Default constructor for the Form_StockViewer class; initializes component UI, 
        ///     sets default values for date pickers based on predefined start and end dates.

        /// </summary>
        public Form_StockViewer()
        {
            InitializeComponent();// Calls method to initialize all components and controls on the form.
            InitializePatternRecognizers();


            startDatePicker.Value = startDate;// Sets the start date picker's value to the predefined start date.
            endDatePicker.Value = endDate;

           

        }

        // Overloaded constructor that accepts a stock path and a date range; reads stock data from the given path and initializes UI to display filtered stock data within the given range.

        public Form_StockViewer(string stockpath, DateTime start, DateTime end)
        {
            InitializeComponent();

            InitializePatternRecognizers();
            allcandlesticks = goReadFile(stockpath);
            startDatePicker.Value = startDate=start;// Sets the start date picker's value to the predefined start date.
            endDatePicker.Value = endDate=end;

            // Calls method to read stock data from the given path and store it in the allcandlesticks list.
            filterCandleSticks();
            display(); // Displays the filtered stock data on the form.
         



        }



        //Opens the file dialog to choose multiple stock when the user clicks on pick a stock button.


        private void button_pickastock_Click(object sender, EventArgs e)
        {
            openFileDialog_TickerChooser.ShowDialog();

        }




        // Event handler for the file dialog's FileOk event
        // Retrieves the selected filename



        /// <summary>
        /// Handles the FileOk event of the OpenFileDialog control, processing the selected file.
        /// This function handles the event triggered after selecting files through the OpenFileDialog. 
        /// It iterates through the selected files, creating a new Form_StockViewer instance for each, 
        /// setting the first selected file's form as the parent and others as child forms. Each form is then 
        /// displayed with a title indicating its "Parent" or "Child" status,
        /// based on the file it represents.
        /// </summary>
        private void openFileDialog_TickerChooser_FileOk(object sender, CancelEventArgs e)
        {
            //Store number of files selected
            int filecount = openFileDialog_TickerChooser.FileNames.Count();
            //Go through each selected filename in the open file dialog
            for (int i = 0; i < filecount; i++)
            {
                //Get the pathname of current file
                string pathName = openFileDialog_TickerChooser.FileNames[i];
                string ticker = Path.GetFileNameWithoutExtension(pathName);

                //Create form to view
                Form_StockViewer form_StockViewer;
                //If first form then set to parent
                if (i == 0)
                {
                    //Read the file and display the stock
                    form_StockViewer = this;
                    LoadAndDisplayStock();
                   
                    form_StockViewer.Text = "Parent: " + ticker;
                }
                else
                {

                    //Instantiate new form using parameter constructor
                    form_StockViewer = new Form_StockViewer(pathName, startDate, endDate);
                    form_StockViewer.Text = "Child: " + ticker;
                   
                }

                //Display the new form
                form_StockViewer.Show();
                form_StockViewer.BringToFront();

            }




        }

       


        //Version 2 :Method to call goReadFile with the filename from the file dialog
        /// <summary>
        /// This method serves as a bridge between the user's file selection action and the actual data processing logic. 
        /// It retrieves the filename from the OpenFileDialog control and passes it to another version of the goReadFile method 
        /// that requires a filename as a parameter. This design allows for the separation of concerns where the UI logic 
        /// (getting the filename from a dialog box) is kept apart from the data processing logic (reading and parsing the file).
        /// The result is the population of the allcandlesticks list with Candlestick objects created from the data in the selected file,
        /// ready for further processing such as filtering and visualization.
        /// </summary>

        private void goReadFile()
        {
            allcandlesticks = goReadFile(openFileDialog_TickerChooser.FileName);
            candlesticksBindingList = new BindingList<smartCandlesticks>();
        }

        //Version 1 :  Method to read candlestick data from a file and return it as a list

        /// <summary>
        /// The goReadFile method in your code is designed to read stock data from a file and transform each line of that file 
        /// into Candlestick objects, which are then added to a list. 
        /// The method showcases how to handle file input operations, parse data, and populate a collection with it
        /// </summary>

        private List<smartCandlesticks> goReadFile(string filename)
        {
            // Temporary list to hold new candlesticks

            List<smartCandlesticks> newcandlesticks = new List<smartCandlesticks>(1024);
            // String that represents the expected format of the first line in the file

            string referenceString = "Date,Open,High,Low,Close,Adj Close,Volume";
            // Opens the file for reading

            using (StreamReader sr = new StreamReader(filename))
            {
                // Clears the current list of all candlesticks


                allcandlesticks.Clear();
                // Reads the first line of the file

                string line = sr.ReadLine();
                // Checks if the first line matches the expected format

                if (line == referenceString)
                {
                    // Reads each subsequent line and creates a Candlestick object from it

                    while ((line = sr.ReadLine()) != null)
                    {
                        smartCandlesticks cs = new smartCandlesticks(line);

                        newcandlesticks.Add(cs);

                    }
                }
                else
                // If the first line doesn't match, sets the form's title to indicate a bad file

                {
                    Text = "Bad File" + filename;

                }
                foreach (Recognizer r in patternRecognizers.Values)
                {
                    //Adds dictionary entries for every pattern on every candlestick
                    r.Recognize_ALL(newcandlesticks);
                }

                return newcandlesticks; //Returning the candlesticks.



            }

        }

       

        private void Form_StockViewer_Load(object sender, EventArgs e)
        { }


        /// <summary>
        /// Initializes the pattern recognizers dictionary with instances of different candlestick pattern recognizers.
        /// </summary>
        private void InitializePatternRecognizers()
        {
            // Clear the existing pattern recognizers dictionary
            patternRecognizers.Clear();

            // Add recognizer instances for various candlestick patterns to the patternRecognizers dictionary
            patternRecognizers.Add("Bullish", new Recognizer_isBullish()); // Recognizer for the Bullish pattern
            patternRecognizers.Add("Bearish", new Recognizer_isBearish()); // Recognizer for the Bearish pattern
            patternRecognizers.Add("Bullish Engulfing", new Recognizer_BullishEngulfing()); // Recognizer for the Bullish Engulfing pattern
            patternRecognizers.Add("Bearish Engulfing", new Recognizer_BearishEngulfing()); // Recognizer for the Bearish Engulfing pattern
            patternRecognizers.Add("Bullish Harami", new Recognizer_BullishHarami()); // Recognizer for the Bullish Harami pattern
            patternRecognizers.Add("Bearish Harami", new Recognizer_BearishHarami()); // Recognizer for the Bearish Harami pattern
            patternRecognizers.Add("Peak", new Recognizer_Peak()); // Recognizer for the Peak pattern
            patternRecognizers.Add("Valley", new Recognizer_Valley()); // Recognizer for the Valley pattern
            patternRecognizers.Add("Neutral", new Recognizer_isNeutral()); // Recognizer for the Neutral pattern
            patternRecognizers.Add("Marubozu", new Recognizer_Marubozu()); // Recognizer for the Marubozu pattern
            patternRecognizers.Add("Hammer", new Recognizer_Hammer()); // Recognizer for the Hammer pattern
            patternRecognizers.Add("Doji", new Recognizer_Doji()); // Recognizer for the Doji pattern
            patternRecognizers.Add("Dragonfly Doji", new Recognizer_Dragonfly_Doji()); // Recognizer for the DragonFly Doji pattern
            patternRecognizers.Add("Gravestone Doji", new Recognizer_GravestoneDoji()); // Recognizer for the Grave stone Doji pattern
            Pattern_comboBox.Items.AddRange(patternRecognizers.Keys.ToArray());

        }


   
       

        /// <summary>
        /// Normalizing the chart by setting appropriate minimum and maximum values for the Y-axis ensures that the data 
        ///displayed uses the full range of the chart area.This makes the chart easier to read and interpret because it
        ///avoids the data being squished into a small part of the chart area,
        ///which can happen if the chart's default scaling is not suitable for the data range.
        /// </summary>
        private void NormalizeChart(BindingList<smartCandlesticks> bindList)
        {
            //Set starting conditions for min and max variables
            decimal min = 1000000000, max = 0;
            //Iterate through each candle stick in list
            foreach (smartCandlesticks c in bindList)
            {
                //Check for greatest value (Ymax) and lowest value (Ymin)
                if (c.low < min) { min = c.low; }
                if (c.high > max) { max = c.high; }
            }
            //Set the Y axis of the chart area to (+-)2% of the ranges rounded to 2 decimal places
            chartMin = chartCandlestick.ChartAreas["ChartArea_OHLC"].AxisY.Minimum = Math.Floor(Decimal.ToDouble(min) * 0.98);
            chartMax = chartCandlestick.ChartAreas["ChartArea_OHLC"].AxisY.Maximum = Math.Ceiling(Decimal.ToDouble(max) * 1.02);


        }

        private void normalizeChart()
        {
            //Go find the minimum and maximum low and high values from all of the candlesticks
            NormalizeChart(candlesticksBindingList);
        }


        /*Linq not necesssary: tasks like filtering data are handled by specific methods (filterCandleSticks, for instance). 
         * This separation of concerns means that data manipulation and querying are encapsulated within those methods, 
         * keeping the event handlers and display logic
         * simpler and focused on their primary roles: responding to user actions and updating the UI.*/

        /// <summary>
        ///Filters the global list of all candlesticks to include only those within a specified date range.This method assumes the existence 
        /// of startDatePicker and endDatePicker controls on the form for determining the date range. The resulting BindingList is used 
        /// both to update a DataGridView with the filtered candlesticks and to redraw a Chart control to reflect the current, filtered dataset.
        /// It's designed to be called whenever the user changes the date selection or when new data is loaded that needs to be filtered 
        /// and displayed according to the current date range selection.

        /// </summary>
        /// 

        private List<smartCandlesticks > filterCandleSticks(List<smartCandlesticks> list, DateTime start, DateTime end)
        {
            // Add the filtered data to the BindingList, which will automatically update the DataGridView
            // Iterates through all candlesticks and adds the ones within the date range to the binding list
            List<smartCandlesticks> filter = new List<smartCandlesticks>(list.Count);
            //Iterate through each candlestick in list
            foreach (smartCandlesticks cs in list)
            {
                //Check if date is inclusively within range and store in filtered list
                if ((cs.date >= start) & (cs.date <= end))
                { filter.Add(cs); }
            }
            return filter;
        }

        public void filterCandleSticks()

        // Retrieves the start and end dates from date pickers on the form

        {
            List<smartCandlesticks> filterCandlesticks = filterCandleSticks(allcandlesticks, startDate, endDate);
            candlesticksBindingList = new BindingList<smartCandlesticks>(filterCandlesticks);
           

            
        }


        
       


        

        

        /// <summary>
        /// This function is displaying the candlesticks and all other filtered data in the 
        /// data-grid-view and chart view in candlesticks high and low .
        /// </summary>
        private void display(BindingList<smartCandlesticks> bindingList)
        {
            // Set the chart's data source to the binding list of candlesticks

            normalizeChart();
            chartCandlestick.Annotations.Clear();

            chartCandlestick.DataSource = bindingList;

            chartCandlestick.DataBind();



        }

        private void display()
        {
            //Go set the data source of grid and chart to binding list and normalize chart
            display(candlesticksBindingList);
        }
        private void LoadAndDisplayStock()
        {
            goReadFile();
            
            filterCandleSticks(); // Filter based on the loaded data and the date range
            normalizeChart();
            // Adjust the chart as necessary
            
            display(); // Display the filtered data
        }

        // Event handler for the click event of updating


        /*The purpose of methods like display and event handlers like button2_Click is often to
         * directly invoke another method or a series of methods without needing to manipulate or query the 
         * data further. LINQ is powerful for querying and transforming collections, but if the action required is
         * straightforward (such as calling another method that does the work), then LINQ may not be necessary.*/

        private void button2_update(object sender, EventArgs e)
        {


            filterCandleSticks();

            display();
        }



        /// <summary>
        /// This function clears any existing annotations from the chart, then iterates through the list of candlesticks. 
        /// For each candlestick, if it matches the selected pattern from the ComboBox,
        /// it creates and adds a new arrow annotation at the corresponding position on the chart.
        /// </summary>
        /// 


        private void Pattern_comboBox_SelectedIndexChanged(object sender, EventArgs e) 
        {
            if (Pattern_comboBox.SelectedItem == null) return;
            
            chartCandlestick.Annotations.Clear();
            if (candlesticksBindingList != null)
            {
                //Iterate through displayed data
                for (int i = 0; i < candlesticksBindingList.Count; i++)
                {
                    //Create smart candlestick for current indexed candlestick
                    smartCandlesticks scs = candlesticksBindingList[i];
                    //Set data point of current candlestick from chart
                    DataPoint point = chartCandlestick.Series[0].Points[i];

                    string selected = Pattern_comboBox.SelectedItem.ToString();    //Store string of pattern name
                    //Displays annotation for current candlestick if selected pattern from dictionary is true
                    if (scs.patterns[selected])
                    {
                        int length = patternRecognizers[selected].patternLength;    //Store length of pattern
                        //Annotate candlesticks for multi-candlestick patterns
                        if (length > 1)
                        {
                            //Skip indexes that cause out of bounds error
                            if (i == 0 | ((i == candlesticksBindingList.Count() - 1) & length == 3))
                            {
                                continue;
                            }
                            //Initialize rectangle annotation
                            RectangleAnnotation rectangle = new RectangleAnnotation();
                            rectangle.SetAnchor(point);

                            double Ymax, Ymin;
                            double width = (90.0 / candlesticksBindingList.Count()) * length; //Scale width to number of candlesticks
                            //Find the min and max between every candlestick in pattern
                            if (length == 2)    //Even number pattern
                            {
                                Ymax = (int)(Math.Max(scs.high, candlesticksBindingList[i - 1].high));
                                Ymin = (int)(Math.Min(scs.low, candlesticksBindingList[i - 1].low));
                                rectangle.AnchorOffsetX = ((width / length) / 2 - 0.25) * (-1);  //Offset even pattern for previous candlestick
                            }
                            else    //Odd number pattern
                            {
                                Ymax = (int)(Math.Max(scs.high, Math.Max(candlesticksBindingList[i + 1].high, candlesticksBindingList[i - 1].high)));
                                Ymin = (int)(Math.Min(scs.low, Math.Min(candlesticksBindingList[i + 1].low, candlesticksBindingList[i - 1].low)));
                            }
                            double height = 40.0 * (Ymax - Ymin) / (chartMax - chartMin); ; //Scale height to chart bounds
                            rectangle.Height = height; rectangle.Width = width;             //Set width and hight
                            rectangle.Y = Ymax;                                             //Set Y to highest Y value for candlesticks
                            rectangle.BackColor = Color.Transparent;                        //Set area to transparent to see chart
                            rectangle.LineWidth = 2;                                        //Set perimeter width
                            rectangle.LineDashStyle = ChartDashStyle.Dash;                  //Set perimeter style to dashed
                            //Add annotation to chart
                            chartCandlestick.Annotations.Add(rectangle);
                        }

                        //Initilialize arrow annotation
                        ArrowAnnotation arrow = new ArrowAnnotation();
                        //Set arrow annotation properties
                        arrow.AxisX = chartCandlestick.ChartAreas[0].AxisX;
                        arrow.AxisY = chartCandlestick.ChartAreas[0].AxisY;
                        arrow.Width = 0.5;
                        arrow.Height = 0.5;
                        //Annotate single pattern and main candlestick for multi-candlesticks
                        arrow.SetAnchor(point);
                        chartCandlestick.Annotations.Add(arrow);
                    }
                }
            }
        }

        
        



        //this is a function which Store starting date

        private void startDatePicker_ValueChanged(object sender, EventArgs e)
        {
            startDate = startDatePicker.Value;

        }

        //this is a function which Store ending date

        private void endDatePicker_ValueChanged(object sender, EventArgs e)
        {
            endDate = endDatePicker.Value;

        }

        }
        
    }

          


