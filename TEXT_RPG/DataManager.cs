using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TEXT_RPG
{
    enum Job{ 마법사,전사,도적,궁수,해적
        }

    internal class DataManager
    {
        string monPath = @"Data\monster.json";
        string skillPath = @"Data\skill.json";
        string  jobPath = @"Data\job.json";
        string itemPath = @"Data\item.json";
        string QuestPath = @"Data\quest.json";
        List<Dictionary<string, object>> jobs;
        List<Dictionary<string, object>> skills;
        List<Dictionary<string, object>> monsters;
        List<Dictionary<string, object>> items;
        List<Dictionary<string, object>> quest;
        //List<string> jobs =new List<string>() { "마법사, 10, 20, 10, 10, 4, skill.StartWizardSkill())", "전사, 10, 20, 10, 10, 5, skill.StartPaladinSkill()",
        //"도적, 10, 20, 10, 10, 8, skill.StartSheepinSkill()","궁수, 10, 20, 10, 10, 7, skill.StartArcherinSkill()","해적, 10, 20, 10, 10, 7, skill.StartPirateinSkill()"};
        private static DataManager instance;
        public static DataManager Instance()
        {
            if (instance == null)
                instance = new DataManager();
            return instance;
        }
        public void Init()
        {
            string j = File.ReadAllText(monPath);
            monsters = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(j);
           j = File.ReadAllText(jobPath);

            jobs = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(j);
          j = File.ReadAllText(skillPath);

            skills = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(j);
           // test();
        }
   



        public Dictionary<string, object> giveJob(int i)
        {
            Console.WriteLine(i);
            Console.WriteLine(jobs.Count);
            return jobs[i];
        }
       
        public Skill MakeSkill(int i)
        {
            Dictionary<string, object> sdata=null;
            foreach (Dictionary<string, object> s in skills)
            {
                if (Convert.ToInt32(s["ID"])== i)
                    sdata = s;
            }
          
            string name = (string)sdata["Name"];
            int Id = Convert.ToInt32(sdata["ID"]);
            TYPE type= (TYPE)Enum.Parse(typeof(TYPE), (string)sdata["Type"]);
            string description = (string)(sdata["Description"]);
            int targetNum = Convert.ToInt32(sdata["TargetNum"]);
            float damage = Convert.ToSingle(sdata["Damage"]);
            int mPCost = Convert.ToInt32(sdata["MPCost"]);
            int critical = Convert.ToInt32(sdata["Critical"]);
           
            return new Skill(Id,name, description, mPCost, damage, type, targetNum, critical);
            

        }
        public Item MakeItem(int i)
        {
            Dictionary<string, object> data = null;
            foreach (Dictionary<string, object> s in items)
            {
                if (Convert.ToInt32(s["ID"]) == i)
                    data = s;
            }
            
            string name = (string)data["Name"];
            string type = (string)data["Type"];
            if (type == "무기")
            {
                //이런식으로 분기
            }
            float atk =Convert.ToSingle(data["atk"]);
            float def = Convert.ToSingle(data["def"]);
            float critical = Convert.ToSingle(data["cri"]);
            float dodge = Convert.ToSingle(data["dodge"]);
            int hp =Convert.ToInt32(data["hp"]);
            int mp = Convert.ToInt32(data["mp"]);
            int recoverHP = Convert.ToInt32(data["recoverHP"]);
            int recoverMP = Convert.ToInt32(data["recoverMP"]);
            int price = Convert.ToInt32(data["price"]);
            int level = Convert.ToInt32(data["level"]);
            return new Weapone("나무 지팡이", "무기", 5, 0, 100, 1, false, false);
        }
        public Quest MakeQuest(int i)
        {
            Dictionary<string, object> data = null;
            foreach (Dictionary<string, object> s in quest)
            {
                if (Convert.ToInt32(s["ID"]) == i)
                    data = s;
            }


            string Title = (string)data["Name"];
            string Etc = (string)data["etc"];
            int TargetCount = Convert.ToInt32(data["TargetCount"]);
            int TargetID = Convert.ToInt32(data["TargetID"]);
            QuestType type = (QuestType)Enum.Parse(typeof(QuestType), (string)data["Type"]);
            return new Quest (Title, Etc, TargetCount,TargetID,type );
           
        }

        public Monster makeMonster(int i)
        {
            Dictionary<string, object> data = null;
            foreach (Dictionary<string, object> s in monsters)
            {
                if (Convert.ToInt32(s["ID"]) == i)
                    data = s;
            }
            string name = (string)data["Name"];
            int Id = Convert.ToInt32(data["ID"]);
            int lv = Convert.ToInt32(data["LV"]);
            int speed = Convert.ToInt32(data["Speed"]);
            int hp= Convert.ToInt32(data["hp"]);
            TYPE weak = (TYPE)Enum.Parse(typeof(TYPE), (string)data["Type"]);
            float atk = Convert.ToSingle(data["atk"]);
            float def = Convert.ToSingle(data["def"]);
            int exp = Convert.ToInt32(data["exp"]);
            int gold = Convert.ToInt32(data["gold"]);
         
            return new Monster(Id, name,lv,weak, atk, def, speed, hp, exp, gold);


        }



        //// 마법사
        //public List<Skill> StartWizardSkill()
        //{
        //    List<Skill> list = new List<Skill>();
        //    list.Add(MakeSkill("매직 미사일", "기본 마법 공격이다", 0, 1.2f, TYPE.Normal, 1, 5));
        //    list.Add(MakeSkill("파이어 볼트", "불 속성 초고열 단일 공격이다", 25, 3.0f, TYPE.Fire, 1, 10));
        //    list.Add(MakeSkill("라이트닝 체인", "번개가 최대 3명의 적을 관통한다", 30, 1.8f, TYPE.Light, 3, 8));
        //    list.Add(MakeSkill("블리자드", "얼음 파편을 광범위로 발사한다", 35, 1.5f, TYPE.Water, 4));
        //    return list;
        //}

        //// 전사
        //public List<Skill> StartPaladinSkill()
        //{
        //    List<Skill> list = new List<Skill>();
        //    list.Add(MakeSkill("발동 격참", "기본 물리 공격이다", 0, 1.5f, TYPE.Normal, 1, 15));
        //    list.Add(MakeSkill("휠윈드", "주변 3명의 적을 베어낸다", 20, 1.8f, TYPE.Normal, 3, 10));
        //    list.Add(MakeSkill("디바인 스매시", "빛의 힘으로 강력한 일격을 날린다", 30, 3.5f, TYPE.Light, 1, 20));
        //    list.Add(MakeSkill("어스 브레이커", "지면을 내리쳐 넓은 범위를 공격한다", 25, 2.0f, TYPE.Normal, 4));
        //    return list;
        //}

        //// 도적
        //public List<Skill> StartSheepinSkill()
        //{
        //    List<Skill> list = new List<Skill>();
        //    list.Add(MakeSkill("기습", "빠르게 적의 약점을 찌른다", 0, 1.0f, TYPE.Normal, 1, 35));
        //    list.Add(MakeSkill("암습", "은신 후 치명적인 공격을 한다", 30, 4.0f, TYPE.Dark, 1, 50));
        //    list.Add(MakeSkill("칠흑의 참격", "어둠의 에너지로 적을 절단한다", 25, 2.5f, TYPE.Dark, 1, 25));
        //    list.Add(MakeSkill("가시 덩굴 그랩", "독성을 지닌 덩굴로 두명의 적을 공격한다", 20, 2.0f, TYPE.Grass, 2, 20));
        //    return list;
        //}

        //// 궁수
        //public List<Skill> StartArcherinSkill()
        //{
        //    List<Skill> list = new List<Skill>();
        //    list.Add(MakeSkill("정밀 사격", "정확하게 약점을 노린다", 0, 1.4f, TYPE.Normal, 1, 25));
        //    list.Add(MakeSkill("애로우 레인", "최대 4명의 적에게 화살비를 내린다", 30, 1.6f, TYPE.Normal, 4, 15));
        //    list.Add(MakeSkill("피어싱 애로우", "2명의 적을 관통하는 강력한 화살이다", 25, 2.2f, TYPE.Normal, 2, 10));
        //    list.Add(MakeSkill("리프 토네이도", "강력한 바람을 일으켜 다수의 적을 공격한다", 20, 2.0f, TYPE.Grass, 3, 10));
        //    return list;
        //}

        //// 해적
        //public List<Skill> StartPirateinSkill()
        //{
        //    List<Skill> list = new List<Skill>();
        //    list.Add(MakeSkill("훅 샷", "갈고리로 적을 할퀴는다", 0, 1.6f, TYPE.Normal, 1, 15));
        //    list.Add(MakeSkill("캐논 발사", "불안정하지만 광역 피해를 준다", 35, 2.8f, TYPE.Fire, 3, 5));
        //    list.Add(MakeSkill("럼 버스트", "압축된 물기둥으로 공격한다", 30, 2.0f, TYPE.Water, 2));
        //    list.Add(MakeSkill("폭풍의 일격", "예측불가의 강력한 타격이다", 40, 3.5f, TYPE.Normal, 1, 30));
        //    return list;
        //}

    }
}
