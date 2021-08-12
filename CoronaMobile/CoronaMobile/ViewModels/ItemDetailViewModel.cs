using CoronaMobile.Models;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace CoronaMobile.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        private string _itemId;
        private string _name;
        private string _address;
        public string Id { get; set; }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string Address
        {
            get => _address;
            set => SetProperty(ref _address, value);
        }

        private Hospital _item;
        public Hospital Item
        {
            get => _item;
            set
            {
                SetProperty(ref _item, value);
                LoadItem(_item);
            }
        }

        public void LoadItem(Hospital item)
        {
            try
            {
                Id = item.Id;
                Name = item.Name;
                Address = item.Address;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to load item");
            }
        }
    }
}
