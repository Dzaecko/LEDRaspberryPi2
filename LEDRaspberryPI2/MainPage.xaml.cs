using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Gpio;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Die Vorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 dokumentiert.

namespace LEDRaspberryPI2
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        GpioPin pin;
        GpioController gpio;       
        private readonly int LEDPIN = 23;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void LEDSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            pin.Write(LEDSwitch.IsOn ? GpioPinValue.Low : GpioPinValue.High);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Lade default GpioController
            gpio = GpioController.GetDefault();

            //Setze Verbindung auf den entsprechenden GPIO-Pin
            pin = gpio.OpenPin(LEDPIN);

            //Setzte Value für den Pin auf High = LED aus           
            pin.Write(GpioPinValue.High);

            //Konfiguriere Pin für Ausgabe
            pin.SetDriveMode(GpioPinDriveMode.Output);
        }
    }
}
