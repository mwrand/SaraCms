namespace SaraCms.Core.Accounts
{
    using Data;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class AccountService
    {
        private readonly IRepository<Account> _dataService;

        public AccountService(IRepository<Account> dataService)
        {
            _dataService = dataService;
        }

        public void Delete(int id)
        {
            _dataService.Delete(id);
        }

        public Account Get(int id)
        {
            var acct = _dataService.Get(id);
            return acct;
        }

        public List<Account> GetAll()
        {
            return _dataService.GetAll();
        }

        public void Save(Account acct)
        {
            _dataService.Save(acct);
        }
    }
}
