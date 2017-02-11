﻿using System;
using System.Linq;

namespace OKHOSTING.UI.Net4.Ajax
{
	public class Platform : UI.Platform
	{
		protected readonly Random Random = new Random();

		public override T Create<T>()
		{
			T control = base.Create<T>();

			//give a default name to all controls to allow events to be correclty triggered
			if (string.IsNullOrWhiteSpace(control.Name))
			{
				control.Name = "ctr_" + Random.Next();
			}

			return control;
		}

		public override void Finish()
		{
			base.Finish();
			System.Web.Security.FormsAuthentication.SignOut();
		}

		//virtual

		public virtual Color Parse(System.Drawing.Color color)
		{
			return new Color(color.A, color.R, color.G, color.B);
		}

		public virtual System.Drawing.Color Parse(Color color)
		{
			return System.Drawing.Color.FromArgb(color.Alpha, color.Red, color.Green, color.Blue);
		}

		public virtual string Parse(HorizontalAlignment value)
		{
			switch (value)
			{
				case HorizontalAlignment.Center:
					return "hotizontal-alignment-center";

				case HorizontalAlignment.Fill:
					return "hotizontal-alignment-fill";

				case HorizontalAlignment.Left:
					return "hotizontal-alignment-left";

				case HorizontalAlignment.Right:
					return "hotizontal-alignment-right";
			}

			throw new ArgumentOutOfRangeException("value");
		}

		public virtual string Parse(VerticalAlignment value)
		{
			switch (value)
			{
				case VerticalAlignment.Center:
					return "vertical-alignment-center";

				case VerticalAlignment.Fill:
					return "vertical-alignment-fill";

				case VerticalAlignment.Top:
					return "vertical-alignment-top";

				case VerticalAlignment.Bottom:
					return "vertical-alignment-bottom";
			}

			throw new ArgumentOutOfRangeException("value");
		}

		public virtual void AddCssClass(System.Web.UI.WebControls.WebControl control, string className)
		{
			if (!control.CssClass.Contains(className))
			{
				control.CssClass = control.CssClass + " " + className;
			}
		}

		public virtual void RemoveCssClass(System.Web.UI.WebControls.WebControl control, string className)
		{
			control.CssClass = control.CssClass.Replace(className, string.Empty).Trim();
		}

		public virtual void RemoveCssClassesStartingWith(System.Web.UI.WebControls.WebControl control, string className)
		{
			var cssClasses = control.CssClass.Split().ToList();

			for (int i = 0; i < cssClasses.Count; i++)
			{
				if (cssClasses[i].StartsWith(className))
				{
					cssClasses.RemoveAt(i);
					i--;
				}
			}

			control.CssClass = control.CssClass.Replace(className, string.Empty).Trim();
		}

		//static

		public static new Platform Current
		{
			get
			{
				var platform = (Platform) UI.Platform.Current;

				if (platform == null)
				{
					platform = new Platform();
					UI.Platform.Current = platform;
				}

				return platform;
			}
		}
	}
}