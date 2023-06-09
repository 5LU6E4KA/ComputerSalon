﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ComputerSalon.Resources
{
	public partial class PasswordBoxWithPasswordViewer : UserControl
	{
		private const char _secureChar = '•';
		private string _password = String.Empty;
		private bool _passwordVisible = false;
		private bool _untraceableChange = false;

		public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
			name: "Text", propertyType: typeof(String), ownerType: typeof(PasswordBoxWithPasswordViewer)
		);

		public static readonly DependencyProperty PlaceholderProperty = DependencyProperty.Register(
			name: "Placeholder", propertyType: typeof(String), ownerType: typeof(PasswordBoxWithPasswordViewer)
		);

		public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register(
			name: "Password", propertyType: typeof(String), ownerType: typeof(PasswordBoxWithPasswordViewer)
		);

		public PasswordBoxWithPasswordViewer()
			=> InitializeComponent();

		public string Password
		{
			get => (string)GetValue(dp: PasswordProperty);
			set => SetValue(dp: PasswordProperty, value: value);
		}

		public string Text
		{
			get => (string)GetValue(dp: TextProperty);
			set => SetValue(dp: TextProperty, value: value);
		}

		public string Placeholder
		{
			get => (string)GetValue(dp: PlaceholderProperty);
			set => SetValue(dp: PlaceholderProperty, value: value);
		}

		private void OnHiddenPasswordClick(object sender, RoutedEventArgs e)
			=> ChangeVisibility(firstBtnName: "ShowPassword", secondBtn: (Button)sender, newText: GetSecureString(length: _password.Length));

		private string GetSecureString(int length)
			=> new String(c: _secureChar, count: length);

		private void OnShowPasswordClick(object sender, RoutedEventArgs e)
			=> ChangeVisibility(firstBtnName: "HiddenPassword", secondBtn: (Button)sender, newText: _password);
		
		private void ChangeVisibility(string firstBtnName, Button secondBtn, string newText)
		{
			Button firstButton = (Button)Tb.Template.FindName(name: firstBtnName, templatedParent: Tb);
			(firstButton.Visibility, secondBtn.Visibility) = (secondBtn.Visibility, firstButton.Visibility);
			_passwordVisible = !_passwordVisible;
			ReplaceTextWithoutTracking(text: newText);
			Tb.SelectionStart = Tb.Text.Length;
		}

		private void ReplaceTextWithoutTracking(string text)
		{
			_untraceableChange = true;
			Tb.Text = text;
			_untraceableChange = false;
		}

		private void OnTbTextChanged(object sender, TextChangedEventArgs e)
		{
			if (_untraceableChange)
				return;

			TextChange change = e.Changes.Last();
			if (change.AddedLength > 0)
				AppendTextToTb(start: change.Offset, count: change.AddedLength);
			else if (change.RemovedLength > 0)
				_password = _password.Remove(startIndex: change.Offset, count: change.RemovedLength);
			Password = _password;
		}

		private void AppendTextToTb(int start, int count)
		{
			string text = Tb.Text;
			string addedText = text.Substring(startIndex: start, length: count);
			_password = _password.Insert(startIndex: start, value: addedText);

			if (_passwordVisible)
				return;

			ReplaceTextWithoutTracking(
				text: text.Remove(startIndex: start, count: count).Insert(startIndex: start, value: GetSecureString(length: count))
			);
			Tb.SelectionStart = start + count;
		}
	}
}
