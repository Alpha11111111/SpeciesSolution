 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using SubSonic.DataProviders;
using SubSonic.Extensions;
using System.Linq.Expressions;
using SubSonic.Schema;
using SubSonic.Repository;
using System.Data.Common;
using SubSonic.SqlGeneration.Schema;

namespace SpeciesSolution.DataAccess.DataModel
{    
    /// <summary>
    /// A class which represents the Taxa table in the Species Database.
    /// </summary>
    public partial class Taxa: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Taxa> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Taxa>(new SpeciesSolution.DataAccess.DataModel.SpeciesDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Taxa> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(Taxa item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Taxa item=new Taxa();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Taxa> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        SpeciesSolution.DataAccess.DataModel.SpeciesDB _db;
        public Taxa(string connectionString, string providerName) {

            _db=new SpeciesSolution.DataAccess.DataModel.SpeciesDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Taxa.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Taxa>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Taxa(){
			_db=new SpeciesSolution.DataAccess.DataModel.SpeciesDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            Id = readRecord.get_long("Id",null);
               
            Rank_Id = readRecord.get_long("Rank_Id",null);
               
            Parent_Id = readRecord.get_long("Parent_Id",null);
               
            TaxaCName = readRecord.get_string("TaxaCName",null);
               
            TaxaLName = readRecord.get_string("TaxaLName",null);
               
            RefArticles = readRecord.get_string("RefArticles",null);
               
            TaxaPic = readRecord.get_string("TaxaPic",null);
        
        }   

        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public Taxa(Expression<Func<Taxa, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Taxa> GetRepo(string connectionString, string providerName){
            SpeciesSolution.DataAccess.DataModel.SpeciesDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new SpeciesSolution.DataAccess.DataModel.SpeciesDB();
            }else{
                db=new SpeciesSolution.DataAccess.DataModel.SpeciesDB(connectionString, providerName);
            }
            IRepository<Taxa> _repo;
            
            if(db.TestMode){
                Taxa.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Taxa>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Taxa> GetRepo(){
            return GetRepo("","");
        }
        
        public static Taxa SingleOrDefault(Expression<Func<Taxa, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Taxa single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Taxa SingleOrDefault(Expression<Func<Taxa, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Taxa single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Taxa, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Taxa, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Taxa> Find(Expression<Func<Taxa, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Taxa> Find(Expression<Func<Taxa, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Taxa> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Taxa> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Taxa> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Taxa> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Taxa> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Taxa> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<long>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
		//********************************************/
		// 修 改 人：Empty（AllEmpty）
		// QQ    群：327360708
		// 博客地址：http://www.cnblogs.com/EmptyFS/
		// 修改时间：2014-07-06
		// 修改说明：将整个实体变量名与值生成字符串输出
		//********************************************/
        public override string ToString(){
			var sb = new StringBuilder();

			sb.Append("Id=" +　Id + "; ");

			sb.Append("Rank_Id=" +　Rank_Id + "; ");

			sb.Append("Parent_Id=" +　Parent_Id + "; ");

			sb.Append("TaxaCName=" +　TaxaCName + "; ");

			sb.Append("TaxaLName=" +　TaxaLName + "; ");

			sb.Append("RefArticles=" +　RefArticles + "; ");

			sb.Append("TaxaPic=" +　TaxaPic + "; ");

			return sb.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Taxa)){
                Taxa compare=(Taxa)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }


        public string DescriptorValue()
        {
            
                return this.TaxaCName.ToString();
            
        }

        public string DescriptorColumn() {
            return "TaxaCName";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "TaxaCName";
        }
        
        #region ' Foreign Keys '

        public IQueryable<Rank> Rank
        {
            get
            {
                
                  var repo=SpeciesSolution.DataAccess.DataModel.Rank.GetRepo();
                  return from items in repo.GetAll()
                       where items.Id == _Rank_Id
                       select items;
            }
        }


        public IQueryable<RefTable> RefTable
        {
            get
            {
                
                  var repo=SpeciesSolution.DataAccess.DataModel.RefTable.GetRepo();
                  return from items in repo.GetAll()
                       where items.Taxa_Id == _Id
                       select items;
            }
        }


        public IQueryable<Taxa> ParentTaxa
        {
            get
            {
                
                  var repo=SpeciesSolution.DataAccess.DataModel.Taxa.GetRepo();
                  return from items in repo.GetAll()
                       where items.Id == _Parent_Id
                       select items;
            }
        }


        #endregion
        


        long _Id;
		/// <summary>
		/// 
		/// </summary>

		[SubSonicPrimaryKey]

        public long Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value || _isLoaded){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        long _Rank_Id;
		/// <summary>
		/// 
		/// </summary>

        public long Rank_Id
        {
            get { return _Rank_Id; }
            set
            {
                if(_Rank_Id!=value || _isLoaded){
                    _Rank_Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Rank_Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        long _Parent_Id;
		/// <summary>
		/// 
		/// </summary>

        public long Parent_Id
        {
            get { return _Parent_Id; }
            set
            {
                if(_Parent_Id!=value || _isLoaded){
                    _Parent_Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Parent_Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _TaxaCName;
		/// <summary>
		/// 
		/// </summary>

        public string TaxaCName
        {
            get { return _TaxaCName; }
            set
            {
                if(_TaxaCName!=value || _isLoaded){
                    _TaxaCName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TaxaCName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _TaxaLName;
		/// <summary>
		/// 
		/// </summary>

        public string TaxaLName
        {
            get { return _TaxaLName; }
            set
            {
                if(_TaxaLName!=value || _isLoaded){
                    _TaxaLName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TaxaLName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _RefArticles;
		/// <summary>
		/// 
		/// </summary>

        public string RefArticles
        {
            get { return _RefArticles; }
            set
            {
                if(_RefArticles!=value || _isLoaded){
                    _RefArticles=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="RefArticles");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _TaxaPic;
		/// <summary>
		/// 
		/// </summary>

        public string TaxaPic
        {
            get { return _TaxaPic; }
            set
            {
                if(_TaxaPic!=value || _isLoaded){
                    _TaxaPic=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TaxaPic");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }




        public DbCommand GetUpdateCommand() {

            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        


            
            if(this._dirtyColumns.Count>0){
				_repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }

        public void Add(){
            Add(_db.DataProvider);
        }
        
        

       
        public void Add(IDataProvider provider){





            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
        
        
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        


        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
            
        }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<Taxa, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            

        }

        


        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
}

