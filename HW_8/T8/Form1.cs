﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using T6;

namespace T8
{
    public partial class Form1 : Form
    {
        public OrderService orderService = new OrderService();
        public Form1()
        {
            InitializeComponent();

            OrderDetails recreationalMachines = new OrderDetails("游戏机", 1000.00);
            OrderDetails handle = new OrderDetails("游戏手柄", 100.00);
            OrderDetails kfc = new OrderDetails("KFC全家桶", 200.00);
            OrderDetails computer = new OrderDetails("电脑", 500.00);
            OrderDetails tea = new OrderDetails("茶叶", 50.00);
            recreationalMachines.number = 1;
            handle.number = 2;
            kfc.number = 5;
            computer.number = 6;
            tea.number = 10;
            Order orderA = new Order("1", "A", "三月一日", "珞珈山路");
            orderA.orderDetails.Add(kfc);
            orderA.orderDetails.Add(tea);
            orderA.AddToSum();
            Order orderB = new Order("4", "B", "三月四日", "珞珈山庄");
            orderB.orderDetails.Add(kfc);
            orderB.orderDetails.Add(computer);
            orderB.AddToSum();
            Order orderC = new Order("3", "C", "三月六日", "洪波门");
            orderC.orderDetails.Add(computer);
            orderC.AddToSum();
            Order orderD = new Order("2", "D", "四月一日", "枫园一路");
            orderD.orderDetails.Add(recreationalMachines);
            orderD.orderDetails.Add(handle);
            orderD.AddToSum();


            orderService.orders.Add(orderA);
            orderService.orders.Add(orderB);
            orderService.orders.Add(orderC);
            orderService.orders.Add(orderD);
            dataGridView1.DataSource = orderService.orders;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 0)//点击订单号id,查看用户名
            {
                Form2 form2 = new Form2(dataGridView1.CurrentCell.Value.ToString(),orderService);
                form2.ShowDialog();
            }

            if (dataGridView1.CurrentCell.ColumnIndex == 2)//点击订单总价格，查询订单详情
            {
                Form3 form3 = new Form3(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString(), orderService);
                form3.ShowDialog();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}