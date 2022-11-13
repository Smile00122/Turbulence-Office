using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento2
{
    public class PassiveAbility_FragileCannon012 : PassiveAbilityBase
    {
        public override int GetBreakDamageReduction(BattleDiceBehavior behavior)
        {
            int memories = 0;
            foreach (BattleDiceCardModel card in this.owner.allyCardDetail.GetAllDeck())
            {
                if (card.GetID() == new LorId("TurbulenceOffice", 51))
                {
                    memories++;
                }
            }
            return memories;
        }
        public override int GetDamageReduction(BattleDiceBehavior behavior)
        {
            int memories = 0;
            foreach (BattleDiceCardModel card in this.owner.allyCardDetail.GetAllDeck())
            {
                if (card.GetID() == new LorId("TurbulenceOffice", 51))
                {
                    memories++;
                }
            }
            return memories;
        }
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            int memories = 0;
            foreach (BattleDiceCardModel card in this.owner.allyCardDetail.GetAllDeck())
            {
                if (card.GetID() == new LorId("TurbulenceOffice", 51))
                {
                    memories++;
                }
            }
            behavior.ApplyDiceStatBonus(new DiceStatBonus
            {
                dmg = memories,
                breakDmg = memories
            });
        }
    }
    public class DiceCardAbility_AddMemoriesTOTarget012 : DiceCardAbilityBase
    {
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            target.allyCardDetail.AddNewCardToDeck(new LorId("TurbulenceOffice", 51), false);
            target.allyCardDetail.AddNewCardToDeck(new LorId("TurbulenceOffice", 51), false);
            target.allyCardDetail.AddNewCardToDeck(new LorId("TurbulenceOffice", 51), false);
        }
    }
    public class PassiveAbility_CollectionOfMemories012 : PassiveAbilityBase
    {
        public override void OnWaveStart()
        {
            trigger = false;
        }
        public override void OnRoundStart()
        {
            if (this.owner.emotionDetail.EmotionLevel >= 3 && trigger == false && this.owner.faction == Faction.Player)
            {
                this.owner.personalEgoDetail.AddCard(new LorId("TurbulenceOffice", 01201));
                trigger = true;
            }
            if (this.owner.emotionDetail.EmotionLevel >= 3 && trigger == false && this.owner.faction == Faction.Enemy)
            {
                this.owner.allyCardDetail.AddNewCard(new LorId("TurbulenceOffice", 01202));
                trigger = true;
            }
            int memories = 0;
            foreach (BattleDiceCardModel card in this.owner.allyCardDetail.GetAllDeck())
            {
                if (card.GetID() == new LorId("TurbulenceOffice", 51))
                {
                    memories++;
                }
            }
            if (memories >= 10)
            {
                for (int i = 0; i < (memories - 10); i++)
                {
                    this.owner.allyCardDetail.ExhaustCardInDeck(new LorId("TurbulenceOffice", 51));
                }
            }
            this.owner.allyCardDetail.AddNewCardToDeck(new LorId("TurbulenceOffice", 51), false);
        }
        private bool trigger;
    }
    public class PassiveAbility_LockedWithintheMind012 : PassiveAbilityBase
    {
        public override void OnDieOtherUnit(BattleUnitModel unit)
        {
            if (unit.faction == this.owner.faction)
            {
                foreach (BattleUnitModel enemy in BattleObjectManager.instance.GetAliveList_opponent(this.owner.faction))
                {
                    enemy.allyCardDetail.AddNewCardToDeck(new LorId("TurbulenceOffice", 51));
                    enemy.allyCardDetail.AddNewCardToDeck(new LorId("TurbulenceOffice", 51));
                    enemy.allyCardDetail.AddNewCardToDeck(new LorId("TurbulenceOffice", 51));
                }
            }
        }
    }
}
