using GalaSoft.MvvmLight;
using MyPaginationControl.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaginationControl.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Student> _students;
        public ObservableCollection<Student> _pageStudents;

        public MainViewModel()
        {
            _students = new ObservableCollection<Student>();
            InitDatas();
        }

        private void InitDatas()
        {
            var random = new Random();
            for (int i = 1; i < 100000; i++)
            {
                _students.Add(new Student()
                {
                    Name = "name" + i,
                    Age = random.Next(1, 100),
                    Birthday = DateTime.Now
                });
            }
        }

        private void ChangePageTo(int index)
        {
            if (index <= 0)
                return;
            PageStudents = new ObservableCollection<Student>(Students.Skip((CurrentPageIndex - 1) * PageSize).Take(PageSize));
        }

        #region property

        private int _currentPageIndex = 1;

        public int CurrentPageIndex
        {
            get { return _currentPageIndex; }
            set
            {
                _currentPageIndex = value;
                ChangePageTo(value);
                RaisePropertyChanged(() => CurrentPageIndex);
            }
        }

        private int _pageSize = 20;

        public int PageSize
        {
            get { return _pageSize; }
        }


        #endregion

        public ObservableCollection<Student> PageStudents
        {
            get { return _pageStudents; }
            set
            {
                _pageStudents = value;
                RaisePropertyChanged(() => PageStudents);
            }
        }

        public ObservableCollection<Student> Students
        {
            get { return _students; }
        }


    }
}
