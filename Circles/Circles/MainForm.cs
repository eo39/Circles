﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Circles
{
    public partial class MainForm : Form
    {
        List<Circle> circles = new List<Circle>();
        private Random random = new Random();

        public MainForm()
        {
            InitializeComponent();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            foreach (Circle circle in circles)
            {
                e.Graphics.FillEllipse(circle.Brush, circle.X, circle.Y, circle.Radius * 2, circle.Radius * 2);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            foreach (Circle circle in circles)
            {
                circle.Update(paintBox.DisplayRectangle);
            }

            circleCountLabel.Text = "Шаров: " + circles.Count;
            Refresh();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            if (timer1.Enabled)
            {
                startButton.Text = "Стоп";
                addPointButton.Visible = true;
                circleCountLabel.Visible = true;
            }
            else
            {
                startButton.Text = "Старт";
                addPointButton.Visible = false;
                circleCountLabel.Visible = false;
            }
        }

        private void AddPointButton_Click(object sender, EventArgs e)
        {
            Circle circle = new Circle(paintBox.DisplayRectangle, random);
            circles.Add(circle);
        }

        private void PaintBox_Paint(object sender, PaintEventArgs e)
        {
            this.paintBox.Paint += OnPaint;
        }
    }
}