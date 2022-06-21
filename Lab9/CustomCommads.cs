using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommandOrderDemo
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand Insert =
                new RoutedUICommand("Insert", "Insert", typeof(CustomCommands));
        public static readonly RoutedUICommand Remove =
                new RoutedUICommand("Remove", "Remove", typeof(CustomCommands));

        public static readonly RoutedUICommand Exit =
                new RoutedUICommand("Exit", "Exit", typeof(CustomCommands),
                    new InputGestureCollection() {
                        new KeyGesture(Key.Q, ModifierKeys.Control) 
                    });
    }
}
