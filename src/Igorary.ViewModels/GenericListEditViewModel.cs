using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Igorary.ViewModels
{
    public class GenericListEditViewModel<TListItemViewModel>: ViewModelBase
    {
        #region List

        public ObservableCollection<TListItemViewModel> ListItems { get; set; }

        private int _pageSize;

        /// <summary>
        /// Get or sets the page size.
        /// </summary>
        public int PageSize {
            get {
                return _pageSize;
            }
            set {
                if (value != _pageSize) {
                    _pageSize = value;
                    RaisePropertyChanged(() => PageSize);
                }
            }
        }

        private int _pageIndex;

        /// <summary>
        /// Gets or sets the current page index (0-based).
        /// </summary>
        public int PageIndex {
            get {
                return _pageIndex;
            }
            set {
                if (value != _pageIndex) {
                    _pageIndex = value;
                    RaisePropertyChanged(() => PageIndex);
                }
            }
        }

        private int _maxPageIndex;

        /// <summary>
        /// Gets the number of pages - 1.
        /// </summary>
        /// <remarks>
        /// Returns -1 if there are no pages.
        /// </remarks>
        public int MaxPageIndex {
            get {
                return _maxPageIndex;
            }
            private set {
                if (value != _maxPageIndex) {
                    _maxPageIndex = value;
                    RaisePropertyChanged(() => MaxPageIndex);
                }
            }
        }

        #region DeleteCommand command

        private RelayCommand _deleteCommand;

        public RelayCommand DeleteCommand {
            get {
                return _deleteCommand ?? (_deleteCommand = new RelayCommand(deleteCommandAction, deleteCommandCanExecute));
            }
        }

        private void deleteCommandAction() {
        }

        private bool deleteCommandCanExecute() {
            return true;
        }
        
        #endregion

        #region NewCommand command

        private RelayCommand _newCommand;

        public RelayCommand NewCommand {
            get {
                return _newCommand ?? (_newCommand = new RelayCommand(newCommandAction, newCommandCanExecute));
            }
        }

        private void newCommandAction() {
        }

        private bool newCommandCanExecute() {
            return true;
        }
        
        #endregion

        #region EditCommand command

        private RelayCommand _editCommand;

        public RelayCommand EditCommand {
            get {
                return _editCommand ?? (_editCommand = new RelayCommand(editCommandAction, editCommandCanExecute));
            }
        }

        private void editCommandAction() {
        }

        private bool editCommandCanExecute() {
            return true;
        }

        

        #endregion

        #region GoToPageCommand command

        private RelayCommand<int> _goToPageCommand;

        public RelayCommand<int> GoToPageCommand {
            get {
                return _goToPageCommand ?? (_goToPageCommand = new RelayCommand<int>(goToPageCommandAction, goToPageCommandCanExecute));
            }
        }

        /// <param name="page">0-based</param>
        private void goToPageCommandAction(int page) {
            // -1 first
            // -2 prev
            // -3 next
            // -4 last
        }

        /// <param name="page">0-based</param>
        private bool goToPageCommandCanExecute(int page) {
            return true;
        }

        #endregion

        #endregion

        #region Edit

        private List<FieldViewModel> _fields;

        public List<FieldViewModel> Fields {
            get {
                return _fields;
            }
            set {
                if (value != _fields) {
                    _fields = value;
                    RaisePropertyChanged(() => Fields);
                }
            }
        }

        #endregion
    }
}
