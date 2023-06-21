using System.Collections.Generic;

namespace ConstructionCompanyManager.Model
{
    
    public class ProjectModel
    {
        // fields
        private int _id;
        private string _projectType;
        private List<float> _sales;
        private List<float> _purchases;
        private bool _isEligibleForTaxRefund;
        
        // constructors
        public ProjectModel(){}
        
        public ProjectModel(string projectType, bool isEligibleForTaxRefund)
        {
            _projectType = projectType;
            _isEligibleForTaxRefund = isEligibleForTaxRefund;
        }

        public ProjectModel(int id, string projectType, bool isEligibleForTaxRefund)
        {
            _id = id;
            _projectType = projectType;
            _isEligibleForTaxRefund = isEligibleForTaxRefund;
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
    }
}