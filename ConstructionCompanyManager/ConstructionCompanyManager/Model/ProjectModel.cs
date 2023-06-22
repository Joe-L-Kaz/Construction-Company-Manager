using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ConstructionCompanyManager.Model
{
    public class ProjectModel
    {
        // fields
        private int _id;
        private string _projectType;
        private ObservableCollection<float> _sales;
        private ObservableCollection<float> _purchases;
        private bool _isEligibleForTaxRefund;

        // constructors
        
        //
        public ProjectModel(string projectType, bool isEligibleForTaxRefund)
        {
            ProjectType = projectType;
            IsEligibleForTaxRefund = isEligibleForTaxRefund;
        }
        
        public ProjectModel(string projectType, bool isEligibleForTaxRefund, ObservableCollection<float> sales,
            ObservableCollection<float> purchases):this(projectType, isEligibleForTaxRefund)
        {
            Sales = sales;
            Purchases = purchases;
        }

        public ProjectModel(int id, string projectType, bool isEligibleForTaxRefund, ObservableCollection<float> sales,
            ObservableCollection<float> purchases):this(projectType,isEligibleForTaxRefund,sales,purchases)
        {
            Id = id;
        }

        public int Id
        {
            get => _id;
            private set => _id = value;
        }

        public string ProjectType
        {
            get => _projectType;
            private set => _projectType = value;
        }

        public bool IsEligibleForTaxRefund
        {
            get => _isEligibleForTaxRefund;
            private set => _isEligibleForTaxRefund = value;
        }

        public ObservableCollection<float> Sales
        {
            get => _sales;
            private set => _sales = value;
        }

        public ObservableCollection<float> Purchases
        {
            get => _purchases;
            private set => _purchases = value;
        }
    }
}