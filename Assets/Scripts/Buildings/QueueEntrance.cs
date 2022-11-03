// namespace Buildings
// {
//     public class QueueEntrance : UpgradableBuildingObject
//     {
//         //Add something to read initial value and increment
//         private int _initialValue;
//         private float _increment = 0.1f;
//         private IProfitable _profitModel;
//         public IProfitable ProfitModel => _profitModel;
//         
//         public override void Initialize(int id, LevelData levelData)
//         {
//             BuildingType = BuildingType.QueueEntrance;
//             objectId = id;
//             this.levelData = levelData;
//             _profitModel = new ProfitModel(_initialValue, _increment, levelData);
//         }
//
//         protected override void IncrementEarningAfterLevelUp()
//         {
//             _profitModel.IncrementEarningAfterLevelUp();
//         }
//     }
// }