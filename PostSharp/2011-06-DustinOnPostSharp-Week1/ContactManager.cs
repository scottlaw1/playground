using System;
using System.Linq;
using System.Windows.Forms;
using PostSharpDemo1.Properties;

namespace PostSharpDemo1
{
    public partial class ContactManager : Form
    {
        private readonly IContactRepository contactRepository;
        private string searchCriteria = string.Empty;

        public ContactManager()
        {
            InitializeComponent();
            contactRepository = new InMemoryDataStore();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Contact cnt = ShowEditorDialog(null);

            if (cnt == null)
            {
                return;
            }

            contactRepository.Insert(cnt);
            UpdateContactList();
        }

        private void UpdateContactList()
        {
            try
            {
                IQueryable<Contact> contacts;

                if (string.IsNullOrEmpty(searchCriteria))
                {
                    contacts = contactRepository.GetAll();
                }
                else
                {
                    contacts = contactRepository.GetByName(searchCriteria);
                }

                PopulateContactsList(contacts);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.ContactManager_UpdateContactList_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateContactsList(IQueryable<Contact> contacts)
        {
            lstContacts.Items.Clear();
            lstContacts.BeginUpdate();

            foreach (Contact c in contacts)
            {
                ListViewItem lvi = BuildListViewItem(c);
                lstContacts.Items.Add(lvi);
            }

            lstContacts.EndUpdate();
        }

        private static ListViewItem BuildListViewItem(Contact c)
        {
            var lvi = new ListViewItem(c.LastName)
                          {
                              Tag = c
                          };

            lvi.SubItems.Add(c.FirstName);
            lvi.SubItems.Add(c.EmailAddress);
            return lvi;
        }

        private Contact ShowEditorDialog(Contact contact)
        {
            var ce = new ContactEditor(contact);
            try
            {
                DialogResult dlgres = ce.ShowDialog();
                Contact cnt = ce.Contact;

                if (dlgres == DialogResult.Cancel)
                {
                    return null;
                }

                return cnt;
            }
            finally
            {
                ce.Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchCriteria = txtSearchCriteria.Text;
            UpdateContactList();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstContacts.SelectedIndices.Count < 1)
            {
                return;
            }

            Contact cnt = ShowEditorDialog(lstContacts.SelectedItems[0].Tag as Contact);

            if (cnt == null)
            {
                return;
            }

            contactRepository.Update(cnt);
            UpdateContactList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstContacts.SelectedIndices.Count < 1)
            {
                return;
            }

            if (
                MessageBox.Show("Are you sure you want to delete this contact?", "Delete", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Exclamation) == DialogResult.No)
            {
                return;
            }

            var cnt = lstContacts.SelectedItems[0].Tag as Contact;

            contactRepository.Delete(cnt);
            UpdateContactList();
        }

        private void ContactManager_Load(object sender, EventArgs e)
        {
            UpdateContactList();
        }
    }
}