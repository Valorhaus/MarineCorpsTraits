using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MarineCorpsTraits
{
    public abstract class Gene_MarineBase : Gene
    {
        private bool effectsApplied;

        public override void PostAdd()
        {
            base.PostAdd();

            if (!effectsApplied)
            {
                ApplyTemplate();
                effectsApplied = true;
            }
        }

        public override void Tick()
        {
            base.Tick();

            // Retroactive support: when loading existing saves
            if (!effectsApplied && pawn != null)
            {
                ApplyTemplate();
                effectsApplied = true;
            }
        }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref effectsApplied, "effectsApplied", false);
        }

        /// <summary>
        /// Implement per-gene skill/trait template here.
        /// </summary>
        protected abstract void ApplyTemplate();

        protected void RemoveMarineLikeTraits()
        {
            if (pawn?.story?.traits == null) return;

            var traitSet = pawn.story.traits;
            var toRemove = new List<Trait>();

            foreach (Trait tr in traitSet.allTraits)
            {
                var defName = tr.def?.defName;
                if (defName == "Marines" || defName == "WarHero")
                {
                    toRemove.Add(tr);
                }
            }

            foreach (Trait tr in toRemove)
            {
                traitSet.RemoveTrait(tr);
            }
        }

        protected void SetAllSkills(int level)
        {
            if (pawn?.skills == null) return;

            foreach (var skill in pawn.skills.skills)
            {
                skill.Level = level;
            }
        }

        protected void SetSkill(SkillDef def, int level)
        {
            if (pawn?.skills == null || def == null) return;

            var record = pawn.skills.GetSkill(def);
            if (record != null)
            {
                record.Level = level;
            }
        }
    }

    // =========================
    //  War Hero gene
    // =========================
    public class Gene_WarHeroTemplate : Gene_MarineBase
    {
        protected override void ApplyTemplate()
        {
            if (pawn == null) return;

            Log.Message($"[MarineCorpsTraits] Applying WAR HERO template to {pawn}.");

            // Remove all Marine/Corpsman/WarHero traits
            RemoveMarineLikeTraits();

            // All skills to 20
            SetAllSkills(20);
        }
    }

    // =========================
    //  Marine gene
    // =========================
    public class Gene_MarineTemplate : Gene_MarineBase
    {
        protected override void ApplyTemplate()
        {
            if (pawn == null) return;

            Log.Message($"[MarineCorpsTraits] Applying MARINE template to {pawn}.");

            // Remove all Marine/Corpsman/WarHero traits
            RemoveMarineLikeTraits();

            // Base: everything 10
            SetAllSkills(10);

            // Shooting, Construction, Melee, Mining, Crafting to 20
            SetSkill(SkillDefOf.Shooting, 20);
            SetSkill(SkillDefOf.Construction, 20);
            SetSkill(SkillDefOf.Melee, 20);
            SetSkill(SkillDefOf.Mining, 20);
            SetSkill(SkillDefOf.Crafting, 20);
        }
    }

    // =========================
    //  Corpsman gene
    // =========================
    public class Gene_CorpsmanTemplate : Gene_MarineBase
    {
        protected override void ApplyTemplate()
        {
            if (pawn == null) return;

            Log.Message($"[MarineCorpsTraits] Applying CORPSMAN template to {pawn}.");

            // Remove all Marine/Corpsman/WarHero traits
            RemoveMarineLikeTraits();

            // Base: everything 10
            SetAllSkills(10);

            // Cooking, Plants, Animals, Medical to 20
            SetSkill(SkillDefOf.Cooking, 20);
            SetSkill(SkillDefOf.Plants, 20);
            SetSkill(SkillDefOf.Animals, 20);
            SetSkill(SkillDefOf.Medicine, 20);
        }
    }
}
