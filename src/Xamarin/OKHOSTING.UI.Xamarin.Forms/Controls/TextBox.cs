﻿using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	public class TextBox : global::Xamarin.Forms.Entry, ITextBox
	{
		void IDisposable.Dispose()
		{
		}

		#region IControl

		string IControl.Name
		{
			get; set;
		}

		bool IControl.Visible
		{
			get
			{
				return base.IsVisible;
			}
			set
			{
				base.IsVisible = value;
			}
		}

		bool IControl.Enabled
		{
			get
			{
				return base.IsEnabled;
			}
			set
			{
				base.IsEnabled = value;
			}
		}

		double? IControl.Width
		{
			get
			{
				return base.WidthRequest;
			}
			set
			{
				if (value.HasValue)
				{
					base.WidthRequest = value.Value;
				}
			}
		}

		double? IControl.Height
		{
			get
			{
				return base.HeightRequest;
			}
			set
			{
				if (value.HasValue)
				{
					base.HeightRequest = value.Value;
				}
			}
		}

		Thickness IControl.Margin
		{
			get; set;
		}

		Color IControl.BackgroundColor
		{
			get
			{
				return App.Current.Parse(base.BackgroundColor);
			}
			set
			{
				base.BackgroundColor = App.Current.Parse(value);
			}
		}

		Color IControl.BorderColor
		{
			get; set;
		}

		Thickness IControl.BorderWidth
		{
			get; set;
		}

		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				return App.Current.Parse(base.HorizontalOptions.Alignment);
			}
			set
			{
				base.HorizontalOptions = new global::Xamarin.Forms.LayoutOptions(App.Current.Parse(value), false);
			}
		}

		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				return App.Current.ParseVerticalAlignment(base.VerticalOptions.Alignment);
			}
			set
			{
				base.VerticalOptions = new global::Xamarin.Forms.LayoutOptions(App.Current.Parse(value), false);
			}
		}

		#endregion

		#region ITextControl

		string ITextControl.FontFamily
		{
			get
			{
				return base.FontFamily;
			}
			set
			{
				base.FontFamily = value;
			}
		}

		Color ITextControl.FontColor
		{
			get
			{
				return App.Current.Parse(base.TextColor);
			}
			set
			{
				base.TextColor = App.Current.Parse(value);
			}
		}

		bool ITextControl.Bold
		{
			get
			{
				return base.FontAttributes.HasFlag(global::Xamarin.Forms.FontAttributes.Bold);
			}
			set
			{
				base.FontAttributes = global::Xamarin.Forms.FontAttributes.Bold;
			}
		}

		bool ITextControl.Italic
		{
			get
			{
				return base.FontAttributes.HasFlag(global::Xamarin.Forms.FontAttributes.Italic);
			}
			set
			{
				base.FontAttributes = global::Xamarin.Forms.FontAttributes.Italic;
			}
		}

		bool ITextControl.Underline
		{
			get;
			set;
		}

		HorizontalAlignment ITextControl.TextHorizontalAlignment
		{
			get;
			set;
		}

		VerticalAlignment ITextControl.TextVerticalAlignment
		{
			get;
			set;
		}

		Thickness ITextControl.TextPadding
		{
			get;
			set;
		}

		#endregion

		ITextBoxInputType ITextBox.InputType
		{
			get
			{
				if (base.Keyboard == global::Xamarin.Forms.Keyboard.Email) return ITextBoxInputType.Email;
				if (base.Keyboard == global::Xamarin.Forms.Keyboard.Numeric) return ITextBoxInputType.Number;
				if (base.Keyboard == global::Xamarin.Forms.Keyboard.Telephone) return ITextBoxInputType.Telephone;
				if (base.Keyboard == global::Xamarin.Forms.Keyboard.Text) return ITextBoxInputType.Text;
				if (base.Keyboard == global::Xamarin.Forms.Keyboard.Url) return ITextBoxInputType.Url;

				return ITextBoxInputType.Text;
            }
			set
			{
				switch (value)
				{
					case ITextBoxInputType.Date:
					case ITextBoxInputType.DateTime:
						base.Keyboard = global::Xamarin.Forms.Keyboard.Default;
						break;

					case ITextBoxInputType.Email:
						base.Keyboard = global::Xamarin.Forms.Keyboard.Email;
						break;

					case ITextBoxInputType.Number:
						base.Keyboard = global::Xamarin.Forms.Keyboard.Numeric;
						break;

					case ITextBoxInputType.Telephone:
						base.Keyboard = global::Xamarin.Forms.Keyboard.Telephone;
						break;

					case ITextBoxInputType.Text:
						base.Keyboard = global::Xamarin.Forms.Keyboard.Text;
						break;

					case ITextBoxInputType.Time:
						base.Keyboard = global::Xamarin.Forms.Keyboard.Default;
						break;

					case ITextBoxInputType.Url:
						base.Keyboard = global::Xamarin.Forms.Keyboard.Url;
						break;

					default:
						base.Keyboard = global::Xamarin.Forms.Keyboard.Default;
						break;
				}
			}
		}
	}
}