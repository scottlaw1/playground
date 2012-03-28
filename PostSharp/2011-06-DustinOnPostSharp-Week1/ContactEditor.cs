using System;
using System.Windows.Forms;

namespace PostSharpDemo1
{
    public partial class ContactEditor : Form
    {
        private ContactEditor()
        {
            InitializeComponent();
        }

        public ContactEditor(Contact contact) : this()
        {
            Contact = contact;
        }

        public Contact Contact { get; private set; }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            Contact.FirstName = txtFirstName.Text;
            Contact.LastName = txtLastName.Text;
            Contact.EmailAddress = txtEmail.Text;

            DialogResult = DialogResult.OK;
        }

        private void ContactEditor_Load(object sender, EventArgs e)
        {
            if (Contact == null)
            {
                Contact = new Contact();
            }

            txtFirstName.Text = Contact.FirstName;
            txtLastName.Text = Contact.LastName;
            txtEmail.Text = Contact.EmailAddress;
        }
    }
}