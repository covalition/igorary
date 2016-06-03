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
    public abstract class GenericListEditViewModel<TListItemViewModel> : ModifiableViewModel where TListItemViewModel : BaseListItemViewModel
    {
        #region List

        public GenericListEditViewModel() {
            reloadItems();
        }

        private async void reloadItems() {
            IsInitializing = true;
            ListItems = new ObservableCollection<TListItemViewModel>(await LoadItems());
            IsInitializing = false;
        }

        protected abstract Task<IEnumerable<TListItemViewModel>> LoadItems();

        private bool _isInitializing;

        public bool IsInitializing {
            get {
                return _isInitializing;
            }
            set {
                if (value != _isInitializing) {
                    _isInitializing = value;
                    RaisePropertyChanged(() => IsInitializing);
                }
            }
        }

        private ObservableCollection<TListItemViewModel> _listItems;

        public ObservableCollection<TListItemViewModel> ListItems {
            get {
                return _listItems;
            }
            set {
                if (value != _listItems) {
                    _listItems = value;
                    RaisePropertyChanged(nameof(ListItems));
                }
            }
        }

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
            Delete();
            SelectedItemIndex = -1;
            reloadItems();
        }

        private bool deleteCommandCanExecute() {
            return !IsNew && SelectedItemIndex != -1;
        }

        #endregion

        #region NewCommand command

        private RelayCommand _newCommand;

        public RelayCommand NewCommand {
            get {
                return _newCommand ?? (_newCommand = new RelayCommand(newCommandAction, newCommandCanExecute));
            }
        }

        private async void newCommandAction() {
            SelectedItemIndex = -1;
            IsNew = true;
            Fields = await LoadFields();
            Modified = true;
        }

        private bool newCommandCanExecute() {
            return !IsNew && !Modified;
        }

        #endregion

        //#region EditCommand command

        //private RelayCommand _editCommand;

        //public RelayCommand EditCommand {
        //    get {
        //        return _editCommand ?? (_editCommand = new RelayCommand(editCommandAction, editCommandCanExecute));
        //    }
        //}

        //private void editCommandAction() {
        //}

        //private bool editCommandCanExecute() {
        //    return Mode == ListEditMode.Browse;
        //}

        //#endregion

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

        //private ListEditMode _mode = ListEditMode.Browse;

        //public ListEditMode Mode {
        //    get {
        //        return _mode;
        //    }
        //    set {
        //        if (value != _mode) {
        //            _mode = value;
        //            NewCommand.RaiseCanExecuteChanged();
        //            //EditCommand.RaiseCanExecuteChanged();
        //            DeleteCommand.RaiseCanExecuteChanged();
        //        }
        //    }
        //}

        private bool _isNew;

        public bool IsNew {
            get {
                return _isNew;
            }
            set {
                if (value != _isNew) {
                    _isNew = value;
                    RaisePropertyChanged(() => IsNew);
                    NewCommand.RaiseCanExecuteChanged();
                    DeleteCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private int _selectedItemIndex = -1;

        public int SelectedItemIndex {
            get {
                return _selectedItemIndex;
            }
            set {
                if (value != _selectedItemIndex) {
                    _selectedItemIndex = value;
                    RaisePropertyChanged(() => SelectedItemIndex);
                    DeleteCommand.RaiseCanExecuteChanged();
                    updateFields();
                }
            }
        }

        private async void updateFields() {
            if (SelectedItemIndex < 0 && !IsNew)
                Fields = null;
            else
                Fields = await LoadFields();
        }

        protected abstract void Delete();

        #endregion

        #region Edit

        private List<LabeledFieldViewModel> _fields;

        public List<LabeledFieldViewModel> Fields {
            get {
                return _fields;
            }
            private set {
                if (value != _fields) {
                    _fields = value;
                    RaisePropertyChanged(() => Fields);
                }
            }
        }

        protected abstract Task<List<LabeledFieldViewModel>> LoadFields();

        #region SaveCommand command

        private RelayCommand _saveCommand;

        public RelayCommand SaveCommand {
            get {
                return _saveCommand ?? (_saveCommand = new RelayCommand(saveCommandAction, saveCommandCanExecute));
            }
        }

        private void saveCommandAction() {
            Save();
            endEdit();
            reloadItems();
        }

        private bool saveCommandCanExecute() {
            return Modified;
        }

        #endregion

        #region CancelCommand command

        private RelayCommand _cancelCommand;

        public RelayCommand CancelCommand {
            get {
                return _cancelCommand ?? (_cancelCommand = new RelayCommand(cancelCommandAction, cancelCommandCanExecute));
            }
        }

        private void cancelCommandAction() {
            endEdit();
        }

        private bool cancelCommandCanExecute() {
            return Modified;
        }

        #endregion

        private void endEdit() {
            Modified = false;
            IsNew = false;
        }

        protected override void OnModifiedChange() {
            SaveCommand.RaiseCanExecuteChanged();
            CancelCommand.RaiseCanExecuteChanged();
        }

        //private bool _modified = false;

        //public bool Modified {
        //    get {
        //        return _modified;
        //    }
        //    set {
        //        if (value != _modified) {
        //            _modified = value;
        //            RaisePropertyChanged(() => Modified);
        //            SaveCommand.RaiseCanExecuteChanged();
        //            CancelCommand.RaiseCanExecuteChanged();
        //        }
        //    }
        //}

        protected abstract void Save();

        #endregion
    }
}
