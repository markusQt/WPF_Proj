using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ToolBoard.CustomControls
{
    public class AnalogUhr : Control
    {
        #region Props
        private Line _HourHand;
        private Line _MinHand;
        private Line _SecHand;
        #endregion

        #region DepProps
        public DependencyProperty ShowSecondsProperty = DependencyProperty.Register("ShowSeconds", typeof(bool), typeof(AnalogUhr), new PropertyMetadata(true));
        public bool ShowSeconds
        {
            get { return (bool)GetValue(ShowSecondsProperty); }
            set { SetValue(ShowSecondsProperty, value); }
        }
        
        #endregion

        static AnalogUhr()
        {
            /*
             * ACHTUNG es muss ein Folder zwingend mit dem Namen Themes angelegt werden, darin ein RessourceDictionary mit dem Namen Generic
             * WPF wird hier nach den Styles für das Control suchen
             * **/
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AnalogUhr), new FrameworkPropertyMetadata(typeof(AnalogUhr)));
        }

        //Zugriff auf die Elemente im Style erhalten, wenn das Template an die Klasse gebunden wird

        public override void OnApplyTemplate()
        {
            _HourHand = (Line)Template.FindName("PART_HourHand", this);
            _MinHand = (Line)Template.FindName("PART_MinHand", this);
            _SecHand = (Line)Template.FindName("PART_SecHand", this);

            #region Binding
            //Das Ganze auch über TemplateBinding moeglich - > siehe AnalogUhrStyle.xaml

          /*  Binding ShowSecondHandBinding = new Binding()
            {
                Path = new PropertyPath(nameof(ShowSeconds)),
                Source = this,
                Converter = new BooleanToVisibilityConverter()
            };
            _SecHand.SetBinding(VisibilityProperty, ShowSecondHandBinding);*/

            #endregion



            DispatcherTimer myTimer = new DispatcherTimer();
            myTimer.Interval = new TimeSpan(0, 0, 1);
            myTimer.Tick += (s,e) => UpdateHandAngles();
            myTimer.Start();
        }

        private void UpdateHandAngles()
        {
            _HourHand.RenderTransform = new RotateTransform((DateTime.Now.Hour / 12.0) * 360, 0.5, 0.5);
            _MinHand.RenderTransform = new RotateTransform((DateTime.Now.Minute / 60.0) * 360, 0.5, 0.5);
            _SecHand.RenderTransform = new RotateTransform((DateTime.Now.Second /60.0) * 360, 0.5, 0.5);
        }
    }
}
