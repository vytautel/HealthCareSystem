using AndroidX.CardView.Widget;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileApp.Components
{

    public class SymptomCard : Frame
    {
        public SymptomCard()
        {
            CornerRadius = 10;
            HasShadow = true;
            BackgroundColor = Color.White;

            var contentLayout = new StackLayout
            {
                Margin = new Thickness(10)
            };

            var titleLabel = new Label
            {
                FontSize = 18,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Black
            };

            var bodyLabel = new Label
            {
                FontSize = 14,
                TextColor = Color.Gray
            };

            contentLayout.Children.Add(titleLabel);
            contentLayout.Children.Add(bodyLabel);

            Content = contentLayout;
        }

        public string Title
        {
            get { return ((Label)((StackLayout)Content).Children[0]).Text; }
            set { ((Label)((StackLayout)Content).Children[0]).Text = value; }
        }

        public string Body
        {
            get { return ((Label)((StackLayout)Content).Children[1]).Text; }
            set { ((Label)((StackLayout)Content).Children[1]).Text = value; }
        }

    }
}
