using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    internal class Armor : Item
    {
        public static List<Armor> Armors = new List<Armor>();

        public Armor(string name, string type, float def, float dodge, int hp, int mp,  // 이름 ,타입 ,방어력 ,회피율 ,쳐력 ,마나 ,
                     int price, int level, bool isHave, bool isEquipped,string mainType)                //가격,착용레벨,소지 여부, 장착 여부
            : base(name, type, 0, def, 0, dodge, hp, mp,0,0 ,price, level, isHave, isEquipped, mainType)
        {
        }
        public Armor(Item item)                //가격,착용레벨,소지 여부, 장착 여부
           : base(item.Name, item.Type, 0, item.Def??0, 0, item.Dodge??0,item.HP??0, item.MP??0, 0, 0, item.Price ?? 0, item.Level ?? 0, item.IsHave, item.IsEquipped, item.MainType)
        {
        }
        

<<<<<<< Updated upstream
<<<<<<< Updated upstream
        public static void AddDefaultArmors() // 기본 방어구 추가
        {
            Armors.Add(new Armor("가죽 갑옷", "Armor", 5, 1f, 0, 0, 100, 1, false, false, "갑옷"));
            Armors.Add(new Armor("철 갑옷", "Armor", 10, 5f, 20, 20, 1000, 15, false, false,"갑옷"));
            Armors.Add(new Armor("은 갑옷", "Armor", 15, 10f, 50, 50, 3000, 30, false, false,"갑옷"));
            Armors.Add(new Armor("금 갑옷", "Armor", 20, 15, 100, 100, 6000, 45, false, false,"갑옷"));
            Armors.Add(new Armor("가죽 신발", "Shoes", 5, 1, 0, 0, 100, 1, false, false, "갑옷"));
            Armors.Add(new Armor("철 신발", "Shoes", 10, 5, 20, 20, 1000, 15, false, false, "갑옷"));
            Armors.Add(new Armor("은 신발", "Shoes", 15, 10, 50, 50, 3000, 30, false, false, "갑옷"));
            Armors.Add(new Armor("금 신발", "Shoes", 20, 15, 100, 100, 6000, 45, false, false, "갑옷"));
            Armors.Add(new Armor("가죽 투구", "Helmet", 5, 1, 0, 0, 100,1, false, false, "갑옷"));
            Armors.Add(new Armor("철 투구", "Helmet", 10, 5, 20, 20, 1000, 15, false, false, "갑옷"));
            Armors.Add(new Armor("은 투구", "Helmet", 15, 10, 50, 50, 3000, 30, false, false, "갑옷"));
            Armors.Add(new Armor("금 투구", "Helmet", 20, 15, 100, 100, 6000, 45, false, false, "갑옷"));
          

        }
=======
        public override string show(int i)
        {
                        string display = "";
            if (i == 0)
            {

=======
        public override string show(int i)
        {
                        string display = "";
            if (i == 0)
            {

>>>>>>> Stashed changes
                if (IsEquipped)
                    display += ($"[red][[E]][/]{Name,-15} | {Type,-5} | 방어력 : {Def,-5} | 회피율 : {Dodge,-5} | 레벨 : {Level,-5} |가격 : {Price}");
                else
                    display = ($"{Name,-15} | {Type,-5} | 방어력 : {Def,-5} | 회피율 : {Dodge,-5} | 레벨 : {Level,-5} | 가격 : {Price}");
            }
            else
            {
                if (IsHave)
                    display += ($"[gray]{Name,-15} | {Type,-5} | 방어력 : {Def,-5} | 회피율 : {Dodge,-5} | 레벨 : {Level,-5} | 판매완료[/]");
                else
                    display = ($"{Name,-15} | {Type,-5} | 방어력 : {Def,-5} | 회피율 : {Dodge,-5} | 레벨 : {Level,-5} | 가격 : {Price}");


            }
            return display;
        }
      

>>>>>>> Stashed changes
    }
}
