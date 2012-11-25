using System;
using System.IO;
using Eto.Drawing;

namespace Eto.Platform.GtkSharp.Drawing
{
	public interface IGtkPixbuf
	{
		Gdk.Pixbuf Pixbuf { get; }

		Gdk.Pixbuf GetPixbuf (Size maxSize);
	}
	
	public interface IImageHandler
	{
		void DrawImage (GraphicsHandler graphics, float x, float y);

		void DrawImage (GraphicsHandler graphics, float x, float y, float width, float height);

		void DrawImage (GraphicsHandler graphics, RectangleF source, RectangleF destination);
		
		void SetImage (Gtk.Image imageView);
		
	}
	
	public abstract class ImageHandler<T, W> : WidgetHandler<T, W>, IImage, IImageHandler
		where W: Image
	{

		#region IImage Members

		public abstract Size Size { get; }
		
		public abstract void SetImage (Gtk.Image imageView);

		#endregion


		public virtual void DrawImage (GraphicsHandler graphics, float x, float y)
		{
			DrawImage (graphics, x, y, Size.Width, Size.Height);
		}

		public virtual void DrawImage (GraphicsHandler graphics, float x, float y, float width, float height)
		{
			DrawImage (graphics, new RectangleF (new Point (0, 0), Size), new RectangleF (x, y, width, height));
		}

		public abstract void DrawImage (GraphicsHandler graphics, RectangleF source, RectangleF destination);


        #region IImage Members


        public int Width
        {
            get { throw new NotImplementedException(); }
        }

        public int Height
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
