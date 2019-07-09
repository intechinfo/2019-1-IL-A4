using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SimpleUnitTests
{

    public class UIElement
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int W { get; set; }
        public int H { get; set; }

        /// <summary>
        /// Gets the parent or null for top-level element.
        /// </summary>
        public UIElement Parent { get; set; }

        public void Click( int xLocal, int yLocal )
        {
            if( !OnPreClick( xLocal, yLocal ) ) return;
            OnClick( xLocal, yLocal );
        }

        protected virtual bool OnPreClick( int xLocal, int yLocal ) => true;

        protected virtual void OnClick( int xLocal, int yLocal ) { }

    }

    public interface IClickListener
    {
        void OnClick( UIElement source, int x, int y );
    }

    public class Button : UIElement
    {
        readonly List<IClickListener> _clickListeners = new List<IClickListener>();

        public string Text { get; set; }

        public Action<UIElement, int, int> Clicked;

        public void AddListener( IClickListener listener ) => _clickListeners.Add( listener );
        public void RemoveListener( IClickListener listener ) => _clickListeners.Remove( listener );

        protected override void OnClick( int xLocal, int yLocal )
        {
            //var h = Clicked;
            //if( h != null ) h( this, xLocal, yLocal );

            Clicked?.Invoke( this, xLocal, yLocal );

            foreach( var l in _clickListeners )
            {
                l.OnClick( this, xLocal, yLocal );
            }
        }
    }

    class Panel : UIElement
    {
        public List<UIElement> Children { get; } = new List<UIElement>();

        protected override void OnClick( int xLocal, int yLocal )
        {
            foreach( var c in Children )
            {
                int cLocalX = xLocal - c.X;
                int cLocalY = yLocal - c.Y;
                if( cLocalX >= 0 && cLocalY >= 0 && cLocalX < c.W && cLocalY < c.H )
                {
                    c.Click( cLocalX, cLocalY );
                    break;
                }
            }
        }
    }

    class MainWindow : Panel, IClickListener
    {
        readonly Panel _left;
        readonly Panel _right;
        readonly Button _rightButton;

        public MainWindow()
        {
            _left = new Panel { X = 10, Y = 10, W = 50, H = 50 };
            Children.Add( _left );
            _left.Parent = this;
            _right = new Panel { X = 100, Y = 10, W = 50, H = 50 };
            Children.Add( _right );
            _right.Parent = this;

            var b = new Button { X = 10, Y = 0, W = 30, H = 20, Text = "I'm Happy" };
            _right.Children.Add( b );
            b.Parent = _right;
            b.AddListener( this );
            b.Clicked += OnClickViaDelegate;
            _rightButton = b;

            var b2 = new Button { X = 10, Y = 0, W = 30, H = 20, Text = "I'm Happy (2)" };
            _left.Children.Add( b2 );
            b2.Parent = _left;
            b2.AddListener( this );
            b2.Clicked += OnClickViaDelegate;
            b2.Clicked += OnClickMore;
        }

        public void OnClickMore( UIElement source, int x, int y )
        {
            Debug.Assert( source == _rightButton );
            Console.WriteLine( "DELEGATE! ON click MORE" );
        }

        public void OnClickViaDelegate( UIElement source, int x, int y )
        {
            if( source == _rightButton )
                Console.WriteLine( "DELEGATE! Right button clicked..." );
            else Console.WriteLine( "DELEGATE! Left button clicked..." );
        }

        public void OnClick( UIElement source, int x, int y )
        {
            if( source == _rightButton ) Console.Beep();
            else Console.WriteLine( "Left button clicked..." );
        }
    }

    [TestFixture]
    public class ObserverTests
    {
        [Test]
        public void onclick_work()
        {
            var w = new MainWindow() { X = 50, Y = 20, W = 1000, H = 180 };

            int osClickX = 99;
            int osClickY = 49;

            w.Click( osClickX - w.X, osClickY - w.Y );
        }

    }
}
