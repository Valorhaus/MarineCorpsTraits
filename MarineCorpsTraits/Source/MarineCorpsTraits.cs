using System.Collections.Generic;
using RimWorld;
using Verse;

namespace MarineCorpsTraits
{
    public abstract class Gene_Base : Gene
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

        /// <summary>
        /// Remove any Marines / WarHero traits (all degrees).
        /// Used before we enforce the correct trait for this gene.
        /// </summary>
        // protected void RemoveMarineLikeTraits()
        // {
            // if (pawn?.story?.traits == null) return;

            // var traitSet = pawn.story.traits;
            // var toRemove = new List<Trait>();

            // foreach (Trait tr in traitSet.allTraits)
            // {
            //     var defName = tr.def?.defName;
            //     if (defName == "Marines" || defName == "WarHero")
            //     {
            //         toRemove.Add(tr);
            //     }
            // }

            // foreach (Trait tr in toRemove)
            // {
            //     traitSet.RemoveTrait(tr);
            // }
        // }

        /// <summary>
        /// Ensure pawn ends up with exactly one instance of the given trait (and degree, if provided).
        /// Removes any existing copies first, then adds the specified one.
        /// </summary>
        // protected void EnsureTrait(string traitDefName, int? degree = null)
        // {
        //     if (pawn?.story?.traits == null) return;

        //     TraitSet traitSet = pawn.story.traits;
        //     TraitDef def = DefDatabase<TraitDef>.GetNamedSilentFail(traitDefName);
        //     if (def == null)
        //     {
        //         Log.Error($"[MarineCorpsTraits] Could not find TraitDef '{traitDefName}' to apply to {pawn}.");
        //         return;
        //     }

        //     // Remove any existing instances of this trait
        //     var toRemove = new List<Trait>();
        //     foreach (Trait tr in traitSet.allTraits)
        //     {
        //         if (tr.def == def)
        //             toRemove.Add(tr);
        //     }
        //     foreach (Trait tr in toRemove)
        //     {
        //         traitSet.RemoveTrait(tr);
        //     }

        //     // Add the desired version
        //     Trait newTrait;
        //     if (degree.HasValue)
        //     {
        //         newTrait = new Trait(def, degree.Value, true);
        //     }
        //     else
        //     {
        //         newTrait = new Trait(def);
        //     }
        //     traitSet.GainTrait(newTrait);
        // }

        /// <summary>
        /// Ensure pawn ends up with the correct gene.
        /// </summary>
        // protected void EnsureGene(string geneDefName)
        // {
        //     GeneDef def = DefDatabase<GeneDef>.GetNamedSilentFail(geneDefName);
        //     if (def == null)
        //     {
        //         Log.Error($"[MarineCorpsTraits] Could not find GeneDef '{geneDefName}' to apply to {pawn}.");
        //         return;
        //     }

        //     // Add the desired version.
        //     // effectsApplied = true; // Prevents crash?
        //     // pawn.genes.AddGene(def, true);
        // }

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
    public class Gene_WarHero : Gene_Base
    {
        protected override void ApplyTemplate()
        {
            if (pawn == null) return;

            Log.Message($"[MarineCorpsTraits] Applying WAR HERO template to {pawn}.");

            // Remove all Marine/Corpsman/WarHero traits
            // RemoveMarineLikeTraits();

            // Ensure WarHero trait is present
            // EnsureTrait("WarHero");

            // All skills to 20
            SetAllSkills(20);

            // Ensures WarHero gene is present
            // EnsureGene("MarineCorps_WarHeroGene");
        }
    }

    // =========================
    //  Marine gene
    // =========================
    public class Gene_Marine : Gene_Base
    {
        protected override void ApplyTemplate()
        {
            if (pawn == null) return;

            Log.Message($"[MarineCorpsTraits] Applying MARINE template to {pawn}.");

            // Remove all Marine/Corpsman/WarHero traits
            // RemoveMarineLikeTraits();

            // Ensure Marines trait (degree 1 = Marine)
            // EnsureTrait("Marines", degree: 1);

            // Base: everything 10
            SetAllSkills(10);

            // Shooting, Construction, Melee, Mining, Crafting to 20
            SetSkill(SkillDefOf.Shooting, 20);
            SetSkill(SkillDefOf.Construction, 20);
            SetSkill(SkillDefOf.Melee, 20);
            SetSkill(SkillDefOf.Mining, 20);
            SetSkill(SkillDefOf.Crafting, 20);

            // Ensures Marine gene is present
            // EnsureGene("MarineCorps_MarineGene");
        }
    }

    // =========================
    //  Corpsman gene
    // =========================
    public class Gene_Corpsman : Gene_Base
    {
        protected override void ApplyTemplate()
        {
            if (pawn == null) return;

            Log.Message($"[MarineCorpsTraits] Applying CORPSMAN template to {pawn}.");

            // Remove all Marine/Corpsman/WarHero traits
            // RemoveMarineLikeTraits();

            // Ensure Marines trait (degree 2 = Corpsman)
            // EnsureTrait("Marines", degree: 2);

            // Base: everything 10
            SetAllSkills(10);

            // Cooking, Plants, Animals, Medical to 20
            SetSkill(SkillDefOf.Cooking, 20);
            SetSkill(SkillDefOf.Plants, 20);
            SetSkill(SkillDefOf.Animals, 20);
            SetSkill(SkillDefOf.Medicine, 20);

            // Ensures Marine gene is present
            // EnsureGene("MarineCorps_CorpsmanGene");
        }
    }
}