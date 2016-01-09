using Cielo.Sirius.Contracts.GetRequestReason;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cielo.Sirius.UI.USD.ProductsAndServices
{
    public class ChangeProductSegmentedParcelledCreditViewModel
    {

        #region Properties

        public ChangeProductSegmentedParcelledCreditRateItem SelectedRateItem
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public GetRequestReasonDTO SelectedReason
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public List<ChangeProductSegmentedParcelledCreditRateItem> ProductRates
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public List<GetRequestReasonDTO> Reasons
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public DateTime SolutionEstimatedDate
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        #endregion

        #region Methods

        public void PreInitialize()
        {
            throw new System.NotImplementedException();
        }

        public void CalculateDefaultSLA()
        {
            throw new System.NotImplementedException();
        }

        public void LoadProductRates()
        {
            throw new System.NotImplementedException();
        }

        public void SendChangeProductInstallmentSegmentedCreditRequest()
        {
            throw new System.NotImplementedException();
        }

        private void OnSelectionChanged()
        {

        }
        private void OnRateChanged()
        {

        }
        private void OnUseParentCompanyRateChanged()
        {

        }

        public void ProcessRateItemSelection()
        {
            throw new System.NotImplementedException();
        }

        public void ValidateProductRates()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Commands

        public int SendChangeCommand
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        #endregion
        
    }
}
