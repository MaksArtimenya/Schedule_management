using Schedule_management.Internal;
using Schedule_management.Objects;

namespace Schedule_management.Forms
{
    public partial class EditingTeachersForm : Form
    {
        private MainPage mainPage;

        public EditingTeachersForm(MainPage mainPage)
        {
            InitializeComponent();
            listBoxShowTeachers.Items.AddRange(InternalData.Teachers.ToArray());
            this.mainPage = mainPage;
        }

        private void buttonDontSave_Click(object sender, EventArgs e)
        {
            groupBoxEditTeacher.Text = "Новый преподаватель";
            listBoxShowTeachers.SelectedIndex = -1;
            textBoxFullName.Text = string.Empty;
            comboBoxGender.SelectedIndex = -1;
            textBoxExperience.Text = string.Empty;
            comboBoxSkill.SelectedIndex = -1;
            comboBoxEducation.SelectedIndex = -1;
            textBoxWorkload.Text = string.Empty;
        }

        private void listBoxShowTeachers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxShowTeachers.SelectedIndex != -1)
            {
                groupBoxEditTeacher.Text = "Редактировать преподавателя";
                buttonRemove.Visible = true;
                Teacher teacher = (Teacher)listBoxShowTeachers.SelectedItem;
                textBoxFullName.Text = teacher.Name;
                comboBoxGender.SelectedIndex = teacher.Gender.Trim() switch
                {
                    "муж" => 0,
                    "жен" => 1,
                    _ => -1,
                };
                textBoxExperience.Text = teacher.Experience.ToString();
                comboBoxSkill.SelectedIndex = teacher.Skill;
                comboBoxEducation.SelectedIndex = teacher.Education;
                textBoxWorkload.Text = InternalData.GetWorkload(teacher);
            }
            else
            {
                groupBoxEditTeacher.Text = "Новый преподаватель";
                buttonRemove.Visible = false;
            }
        }

        private void textBoxFullName_TextChanged(object sender, EventArgs e)
        {
            CheckTextBoxes();
        }

        private void comboBoxGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckTextBoxes();
        }

        private void textBoxExperience_TextChanged(object sender, EventArgs e)
        {
            CheckTextBoxes();
        }

        private void comboBoxSkill_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckTextBoxes();
        }

        private void comboBoxEducation_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckTextBoxes();
        }

        private void CheckTextBoxes()
        {
            if (textBoxFullName.Text != string.Empty && comboBoxGender.SelectedIndex != -1 &&
                textBoxExperience.Text != string.Empty && comboBoxSkill.SelectedIndex != -1 && comboBoxEducation.SelectedIndex != -1)
            {
                buttonSave.Enabled = true;
            }
            else
            {
                buttonSave.Enabled = false;
            }
        }

        private void checkBoxDetail_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDetail.Checked)
            {
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                textBoxBaseRate.Visible = true;
                textBoxNormOfHours.Visible = true;
                textBoxWorkload.Visible = true;
                textBoxCalculation.Visible = true;
            }
            else
            {
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                textBoxBaseRate.Visible = false;
                textBoxNormOfHours.Visible = false;
                textBoxWorkload.Visible = false;
                textBoxCalculation.Visible = false;
            }
        }

        private void textBoxWorkload_TextChanged(object sender, EventArgs e)
        {
            CalculateSalary();
        }

        private void textBoxBaseRate_TextChanged(object sender, EventArgs e)
        {
            CalculateSalary();
        }

        private void textBoxNormOfHours_TextChanged(object sender, EventArgs e)
        {
            CalculateSalary();
        }

        private void CalculateSalary()
        {
            try
            {
                textBoxSalary.Text = Math.Round(double.Parse(textBoxBaseRate.Text) / double.Parse(textBoxNormOfHours.Text) * double.Parse(textBoxWorkload.Text) * 4, 2).ToString();
                textBoxCalculation.Text = $"({textBoxBaseRate.Text}/{textBoxNormOfHours.Text})*{textBoxWorkload.Text}*4={textBoxSalary.Text}";
            }
            catch
            {
                textBoxSalary.Text = "-";
                textBoxCalculation.Text = "-";
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (groupBoxEditTeacher.Text == "Новый преподаватель")
            {
                InternalData.AddTeacher(new Teacher(textBoxFullName.Text, comboBoxGender.Text, int.Parse(textBoxExperience.Text),
                    comboBoxSkill.SelectedIndex, comboBoxEducation.SelectedIndex));
                mainPage.UpdateTeachers();
                listBoxShowTeachers.Items.Clear();
                listBoxShowTeachers.Items.AddRange(InternalData.Teachers.ToArray());
                buttonDontSave_Click(sender, e);
            }
            else
            {
                InternalData.EditTeacher((Teacher)listBoxShowTeachers.SelectedItem, new Teacher(textBoxFullName.Text, comboBoxGender.Text, int.Parse(textBoxExperience.Text),
                    comboBoxSkill.SelectedIndex, comboBoxEducation.SelectedIndex));
                mainPage.UpdateTeachers();
                listBoxShowTeachers.Items.Clear();
                listBoxShowTeachers.Items.AddRange(InternalData.Teachers.ToArray());
                buttonDontSave_Click(sender, e);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            InternalData.RemoveTeacher((Teacher)listBoxShowTeachers.SelectedItem);
            mainPage.UpdateAllListBoxes();
            mainPage.UpdateTeachers();
            listBoxShowTeachers.Items.Clear();
            listBoxShowTeachers.Items.AddRange(InternalData.Teachers.ToArray());
            buttonDontSave_Click(sender, e);
        }
    }
}
