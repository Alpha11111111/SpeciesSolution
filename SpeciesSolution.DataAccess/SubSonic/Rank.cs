 
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
    /// A class which represents the Rank table in the Species Database.
    /// </summary>
    public partial class Rank: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Rank> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Rank>(new SpeciesSolution.DataAccess.DataModel.SpeciesDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Rank> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(Rank item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Rank item=new Rank();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Rank> _repo;
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
        public Rank(string connectionString, string providerName) {

            _db=new SpeciesSolution.DataAccess.DataModel.SpeciesDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Rank.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Rank>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Rank(){
			_db=new SpeciesSolution.DataAccess.DataModel.SpeciesDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            Id = readRecord.get_long("Id",null);
               
            RankLevel = readRecord.get_string("RankLevel",null);
               
            RankCName = readRecord.get_string("RankCName",null);
               
            RankEName = readRecord.get_string("RankEName",null);
        
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

        public Rank(Expression<Func<Rank, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Rank> GetRepo(string connectionString, string providerName){
            SpeciesSolution.DataAccess.DataModel.SpeciesDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new SpeciesSolution.DataAccess.DataModel.SpeciesDB();
            }else{
                db=new SpeciesSolution.DataAccess.DataModel.SpeciesDB(connectionString, providerName);
            }
            IRepository<Rank> _repo;
            
            if(db.TestMode){
                Rank.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Rank>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Rank> GetRepo(){
            return GetRepo("","");
        }
        
        public static Rank SingleOrDefault(Expression<Func<Rank, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Rank single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Rank SingleOrDefault(Expression<Func<Rank, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Rank single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Rank, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Rank, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Rank> Find(Expression<Func<Rank, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Rank> Find(Expression<Func<Rank, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Rank> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Rank> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Rank> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Rank> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Rank> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Rank> GetPaged(int pageIndex, int pageSize) {
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

			sb.Append("RankLevel=" +　RankLevel + "; ");

			sb.Append("RankCName=" +　RankCName + "; ");

			sb.Append("RankEName=" +　RankEName + "; ");

			return sb.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Rank)){
                Rank compare=(Rank)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }


        public string DescriptorValue()
        {
            
                return this.RankLevel.ToString();
            
        }

        public string DescriptorColumn() {
            return "RankLevel";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "RankLevel";
        }
        
        #region ' Foreign Keys '

        public IQueryable<Taxa> Taxa
        {
            get
            {
                
                  var repo=SpeciesSolution.DataAccess.DataModel.Taxa.GetRepo();
                  return from items in repo.GetAll()
                       where items.Rank_Id == _Id
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


        string _RankLevel;
		/// <summary>
		/// 
		/// </summary>

        public string RankLevel
        {
            get { return _RankLevel; }
            set
            {
                if(_RankLevel!=value || _isLoaded){
                    _RankLevel=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="RankLevel");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _RankCName;
		/// <summary>
		/// 
		/// </summary>

        public string RankCName
        {
            get { return _RankCName; }
            set
            {
                if(_RankCName!=value || _isLoaded){
                    _RankCName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="RankCName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }


        string _RankEName;
		/// <summary>
		/// 
		/// </summary>

        public string RankEName
        {
            get { return _RankEName; }
            set
            {
                if(_RankEName!=value || _isLoaded){
                    _RankEName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="RankEName");
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


        public static void Delete(Expression<Func<Rank, bool>> expression) {
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

