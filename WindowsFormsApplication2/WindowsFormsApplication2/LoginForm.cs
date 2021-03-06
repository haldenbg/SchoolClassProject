﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace WindowsFormsApplication2
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        void SetDeafultValueStudent()
        {

            insertNameTxtBox.Text = "ChesterOsborneDixon";
            insertEGNTxtBox.Text = "3390475302";
            loginSelectComboBox.SelectedIndex = 1;
        }
        void SetDeafultValueTeacher()
        {
            insertNameTxtBox.Text = "JoyceGreerWood";
            insertEGNTxtBox.Text = "6561865618";
            loginSelectComboBox.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SetDeafultValueStudent();
          //SetDeafultValueTeacher();
            //Проверка за избора на  teacher and student 
            if (loginSelectComboBox.SelectedIndex == 1)//Checks if student option is sellected in combo box
            {
                string egnPass = String.Empty;
                bool studentExists = false;//Checks if a Student with the stated personal number exists and if he has written the correct name
                bool studentNameIsCorrect = false;
                using (ClassbookEntities context = new ClassbookEntities())
                {
                    if (context.Students.Any(c => c.PersonalNumber == insertEGNTxtBox.Text))
                    {
                        studentExists = true;
                        Student student = context.Students.FirstOrDefault(c => c.PersonalNumber == insertEGNTxtBox.Text);
                        if (student.FirstName + student.MiddleName + student.LastName == insertNameTxtBox.Text.Replace(" ", string.Empty))//да се погледне
                        {
                            studentNameIsCorrect = true;
                            egnPass = student.PersonalNumber;
                        }
                    }
                }
                if (studentExists && studentNameIsCorrect)
                {

                    this.Hide();
                    StudentsForm studentsForm = new StudentsForm(egnPass);
                    studentsForm.Show();
                    studentsForm.Closed += (s, args) => this.Show();
                }
                else
                {
                    MessageBox.Show("No such student", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }    
            else
            {
                if (loginSelectComboBox.SelectedIndex == 0)//Checks if teacher option is sellected in combo box
                {
                    //Checks if a teacher with the stated personal number exists and if he has written the correct name
                    string egnPass = String.Empty;
                    bool teacherExists = false;
                    bool teacherNameIsCorrect = false;
                    using (ClassbookEntities context = new ClassbookEntities())
                    {
                        if (context.Teachers.Any(c => c.PersonalNumber == insertEGNTxtBox.Text))
                        {
                            teacherExists = true;
                            Teacher teacher = context.Teachers.FirstOrDefault(c => c.PersonalNumber == insertEGNTxtBox.Text);
                            if (teacher.FirstName + teacher.MiddleName + teacher.LastName == insertNameTxtBox.Text.Replace(" ", string.Empty))
                            {
                                teacherNameIsCorrect = true;
                                egnPass = teacher.PersonalNumber;
                            }
                        }
                    }
                    if (teacherExists && teacherNameIsCorrect)
                    {
                        this.Hide();
                        TeacherForm teacherForm = new TeacherForm(egnPass);
                        teacherForm.Show();
                        teacherForm.Closed += (s, args) => this.Show();
                    }
                    else
                    {
                        MessageBox.Show("No such teacher", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else MessageBox.Show("No position selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            registerForm.Closed += (s, args) => this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
