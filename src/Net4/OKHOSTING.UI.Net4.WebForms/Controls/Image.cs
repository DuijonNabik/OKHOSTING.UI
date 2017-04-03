﻿using System;
using System.Linq;
using System.IO;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	/// <summary>
	/// It represents an image to which we can give you design through its properties.
	/// <para xml:lang="es">Representa una imagen a la cual le podemos dar diseño por medio de sus propiedades.</para>
	/// </summary>
	public class Image : System.Web.UI.WebControls.Image, IImage
	{
		#region IControl

		/// <summary>
		/// Gets or sets the name of the Image.
		/// <para xml:lang="es">Obtiene o establece el nombre de la imagen</para>
		/// </summary>
		/// <value>The name of the Image.
		/// <para xml:lang="es">El nombre de la imagen.</para>
		/// </value>
		string IControl.Name
		{
			get
			{
				return base.ID;
			}
			set
			{
				base.ID = value;
			}
		}

		/// <summary>
		/// Gets or sets the BackgroundColor of the Image.
		/// <para xml:lang="es">Obtiene o establece el color de fondo de la imagen.</para>
		/// </summary>
		/// <value>The BackgroundColor of the Image.
		/// <para xml:lang="es">El color de fondo de la imagen.</para>
		/// </value>
		Color IControl.BackgroundColor
		{
			get
			{
				return Platform.Current.Parse(base.BackColor);
			}
			set
			{
				base.BackColor = Platform.Current.Parse(value);
			}
		}

		/// <summary>
		/// Gets or sets of the BorderColor of the Image.
		/// <para xml:lang="es">Obtiene o establece el color del borde de la imagen.</para>
		/// </summary>
		/// <value>The BorderColor of the Image.
		/// <para xml:lang="es">El color del borde de la imagen.</para>
		/// </value>
		Color IControl.BorderColor
		{
			get
			{
				return Platform.Current.Parse(base.BorderColor);
			}
			set
			{
				base.BorderColor = Platform.Current.Parse(value);
			}
		}

		/// <summary>
		/// Gets or sets the Width the Imagen.
		/// <para xml:lang="es">Obtien o establece el ancho de la imagen.</para>
		/// </summary>
		/// <value>The width of the Image.
		/// <para xml:lang="es">El ancho de la imagen.</para>
		/// </value>
		double? IControl.Width
		{
			get
			{
				if (base.Width.IsEmpty)
				{
					return null;
				}

				return base.Width.Value;
			}
			set
			{
				if (value.HasValue)
				{
					base.Width = new System.Web.UI.WebControls.Unit(value.Value, System.Web.UI.WebControls.UnitType.Pixel);
				}
				else
				{
					base.Width = new System.Web.UI.WebControls.Unit();
				}
			}
		}

		/// <summary>
		/// Gets or sets the Height the Image.
		/// <para xml:lang="es">Obtiene o establece la altura de la imagen.</para>
		/// </summary>
		/// <value>The height of the Image.
		/// <para xml:lang="es">La altura de la imagen.</para>
		/// </value>
		double? IControl.Height
		{
			get
			{
				if (base.Height.IsEmpty)
				{
					return null;
				}

				return base.Height.Value;
			}
			set
			{
				if (value.HasValue)
				{
					base.Height = new System.Web.UI.WebControls.Unit(value.Value, System.Web.UI.WebControls.UnitType.Pixel);
				}
				else
				{
					base.Height = new System.Web.UI.WebControls.Unit();
				}
			}
		}

		/// <summary>
		/// Gets or sets the Margin the Image.
		/// <para xml:lang="es">Obtiene o establece el margen de la imagen.</para>
		/// </summary>
		/// <value>The Margin of the Image.
		/// <para xml:lang="es">El margen de la imagen.</para>
		/// </value>
		Thickness IControl.Margin
		{
			get
			{
				double left, top, right, bottom;
				Thickness thickness = new Thickness();

				if (double.TryParse(base.Style["margin-left"], out left)) thickness.Left = left;
				if (double.TryParse(base.Style["margin-top"], out top)) thickness.Top = top;
				if (double.TryParse(base.Style["margin-right"], out right)) thickness.Right = right;
				if (double.TryParse(base.Style["margin-bottom"], out bottom)) thickness.Bottom = bottom;

				return new Thickness(left, top, right, bottom);
			}
			set
			{
				if (value.Left.HasValue) base.Style["margin-left"] = string.Format("{0}px", value.Left);
				if (value.Top.HasValue) base.Style["margin-top"] = string.Format("{0}px", value.Top);
				if (value.Right.HasValue) base.Style["margin-right"] = string.Format("{0}px", value.Right);
				if (value.Bottom.HasValue) base.Style["margin-bottom"] = string.Format("{0}px", value.Bottom);
			}
		}

		/// <summary>
		/// Gets or sets of the BorderWidht of the Image.
		/// <para xml:lang="es">Obtiene o establece el ancho del borde de la imagen.</para>
		/// </summary>
		/// <value>The BorderWidth of the Image.
		/// <para xml:lang="es">El ancho del borde de la imagen.</para>
		/// </value>
		Thickness IControl.BorderWidth
		{
			get
			{
				double left, top, right, bottom;
				Thickness thickness = new Thickness();

				if (double.TryParse(base.Style["border-left-width"], out left)) thickness.Left = left;
				if (double.TryParse(base.Style["border-top-width"], out top)) thickness.Top = top;
				if (double.TryParse(base.Style["border-right-width"], out right)) thickness.Right = right;
				if (double.TryParse(base.Style["border-bottom-width"], out bottom)) thickness.Bottom = bottom;

				return new Thickness(left, top, right, bottom);
			}
			set
			{
				if (value.Left.HasValue) base.Style["border-left-width"] = string.Format("{0}px", value.Left);
				if (value.Top.HasValue) base.Style["border-top-width"] = string.Format("{0}px", value.Top);
				if (value.Right.HasValue) base.Style["border-right-width"] = string.Format("{0}px", value.Right);
				if (value.Bottom.HasValue) base.Style["border-bottom-width"] = string.Format("{0}px", value.Bottom);
			}
		}

		/// <summary>
		/// Gets or sets the HorizontalAlignment of the Image.
		/// <para xml:lang="es">Obtiene o establece la alineacion horixontal de la imagen</para>
		/// </summary>
		/// <value>The HorizontalAlignment of the Image.
		/// <para xml:lang="es">La alineacion horizontal de la imagen.</para>
		/// </value>
		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				string cssClass = base.CssClass.Split().Where(c => c.StartsWith("horizontal-alignment")).SingleOrDefault();

				//if not horizontal alignment is provided, the alignment back to the left.
				if (string.IsNullOrWhiteSpace(cssClass))
				{
					return HorizontalAlignment.Left;
				}

				//Verify the horizontal alignment provided.
				if (cssClass.EndsWith("left"))
				{
					return HorizontalAlignment.Left;
				}
				else if (cssClass.EndsWith("right"))
				{
					return HorizontalAlignment.Right;
				}
				else if (cssClass.EndsWith("center"))
				{
					return HorizontalAlignment.Center;
				}
				else if (cssClass.EndsWith("fill"))
				{
					return HorizontalAlignment.Fill;
				}
				else
				{
					return HorizontalAlignment.Left;
				}
			}
			set
			{
				Platform.Current.RemoveCssClassesStartingWith(this, "horizontal-alignment");
				Platform.Current.AddCssClass(this, "horizontal-alignment-" + value.ToString().ToLower());
			}
		}

		/// <summary>
		/// Gets or sets the VerticalAlignment of the Image.
		/// <para xml:lang="es">Obtiene o establece la alineacion vertical de la imagen</para>
		/// </summary>
		/// <value>The VerticalAlignment of the image.
		/// <para xml:lang="es">La alineación vertical de la imagen.</para>
		/// </value>
		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				string cssClass = base.CssClass.Split().Where(c => c.StartsWith("vertical-alignment")).SingleOrDefault();

				//if not vertical alignment is provided, the alignment back to the top.
				if (string.IsNullOrWhiteSpace(cssClass))
				{
					return VerticalAlignment.Top;
				}

				//Verify the vertical alignment provided.
				if (cssClass.EndsWith("top"))
				{
					return VerticalAlignment.Top;
				}
				else if (cssClass.EndsWith("bottom"))
				{
					return VerticalAlignment.Bottom;
				}
				else if (cssClass.EndsWith("center"))
				{
					return VerticalAlignment.Center;
				}
				else if (cssClass.EndsWith("fill"))
				{
					return VerticalAlignment.Fill;
				}
				else
				{
					return VerticalAlignment.Top;
				}
			}
			set
			{
				Platform.Current.RemoveCssClassesStartingWith(this, "vertical-alignment");
				Platform.Current.AddCssClass(this, "vertical-alignment-" + value.ToString().ToLower());
			}
		}

		/// <summary>
		/// Gets or sets an arbitrary object value that can be used to store custom information about this element. 
		/// <para xml:lang="es">Obtiene o establece un valor de objeto arbitrario que puede ser usado para almacenar informacion personalizada sobre este elemento.</para>
		/// </summary>
		/// <remarks>
		/// Returns the intended value. This property has no default value.
		/// <para xml:lang="es">Devuelve el valor previsto. Esta propiedad no contiene un valor predeterminado.</para>
		/// </remmarks>
		object IControl.Tag
		{
			get; set;
		}

		#endregion

		/// <summary>Load the image from files
		/// <para xml:lang="es">Carga la imagen desde los archivos</para> 
		/// </summary>
		/// <returns>The from file.
		/// <para xml:lang="es">El archivo</para>
		/// </returns>
		/// <param name="filePath">File path.
		/// <para xml:lang="es">La ruta del archivo</para>
		/// </param>
		public void LoadFromFile(string filePath)
		{
			if (!File.Exists(filePath))
			{
				throw new ArgumentOutOfRangeException("filePath", "The file does not exist");
			}

			//file is not located inside the web app, so we create a copy in a temp directory			
			if (!filePath.StartsWith(this.Page.MapPath("/")))
			{
				string tempDirectoryPath = Path.Combine(OKHOSTING.Core.Net4.DefaultPaths.Custom, "Temp");

				if (!Directory.Exists(tempDirectoryPath))
				{
					Directory.CreateDirectory(tempDirectoryPath);
				}
			}

			//we finally get the "relative" path of the file and load it as a url
			string url = filePath.Replace(this.Page.MapPath("/"), string.Empty);
			LoadFromUrl(new Uri(url));
		}

		/// <summary>
		/// Loads from stream.
		/// </summary>
		/// <returns>The from stream.</returns>
		/// <param name="stream">Stream.</param>
		public void LoadFromStream(Stream stream)
		{
			//save the stream to a temp file, and load as file from there
			string tempDirectoryPath = Path.Combine(Core.Net4.DefaultPaths.Custom, "Temp");

			if (!Directory.Exists(tempDirectoryPath))
			{
				Directory.CreateDirectory(tempDirectoryPath);
			}

			string tempFilePath = Path.Combine(tempDirectoryPath, Guid.NewGuid().ToString());
			using (var fileStream = File.OpenWrite(tempFilePath))
			{
				stream.CopyTo(fileStream);
			}

			LoadFromFile(tempFilePath);
		}

		/// <summary>
		/// Upload the file from an Internet address
		/// <para xml:lang="es">Carga el archivo desde una direccion de internet</para> 
		/// </summary>
		/// <returns>The from URL.
		/// <para xml:lang="es">La direccion de internet.</para>
		/// </returns>
		/// <param name="url">URL.</param>
		public void LoadFromUrl(System.Uri url)
		{
			base.ImageUrl = url.ToString();
		}
	}
}
