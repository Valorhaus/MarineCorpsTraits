🪖 Marine Corps Genetics
Supersoldier Gene & Trait Framework for RimWorld

Marine Corps Genetics introduces a scalable supersoldier progression system using three custom genes and three matching traits. Each specialization — Corpsman, Marine, and War Hero — rewrites a pawn into an optimized battlefield role with powerful but balanced enhancements.
Unlike godmode mods (e.g. Apotheosis), this mod delivers lore-friendly, progressive, and sanity-preserving superhuman tiers with clean XML and C# hybrid behavior.

📦 Features
🔥 Three Complete Gene Templates

Each gene:

Removes any pre-existing Marine/Corpsman/WarHero traits
Applies the correct specialization trait
Sets associated skills to the correct levels
Runs automatically even in old saves (retroactive support)

💪 Three Scaled Supersoldier Traits

Balanced tiers based on role:
Tier	Focus	Summary
Corpsman	Medic/Survival	Fast healer, strong immunity, 2× work/move/learn, extreme environment tolerance
Marine	Frontline Assault	High combat stats, strong armor, 3× work/move/learn, heavy carry capacity
War Hero	Endgame Apex	Insane work/learn/move, extreme tanking, max toxin immunity, perfect soldier template

🧬 Skill Templates (C#)

Corpsman: Cooking/Plants/Animals/Medical 20, rest 10
Marine: Shooting/Construction/Melee/Mining/Crafting 20, rest 10
War Hero: All skills 20

🔥 Environmental Hardening

All three tiers:
Comfy temperature: -100°C → +200°C
Fully mental-break immune
Reduced hunger rate
Scaled toxin resistance
Scaled healing via InjuryHealingFactor

⚙ Retroactive Behavior

Install anytime — all pawns with these genes auto-update the moment you load your save.

🧬 Genes
Marine Corps: Corpsman Gene
DefName: MarineCorps_CorpsmanGene
Role: Medic / Field Technician

On Application:
Removes Marine, Corpsman, WarHero traits

Sets skills:
Cooking/Plants/Animals/Medical = 20
All others = 10
Applies the Corpsman trait (Marines, degree 2)

Marine Corps: Marine Gene
DefName: MarineCorps_MarineGene
Role: Frontline assault super-soldier

On Application:
Removes Marine, Corpsman, WarHero traits

Sets skills:
Shooting/Construction/Melee/Mining/Crafting = 20
All others = 10
Applies the Marine trait (Marines, degree 1)

Marine Corps: War Hero Gene
DefName: MarineCorps_WarHeroGene
Role: Apex endgame juggernaut

On Application:
Removes Marine, Corpsman, WarHero traits
Sets all skills to 20
Applies the WarHero trait

💪 Traits
Corpsman Trait
TraitDef: Marines — Degree 2

Survival & Physiology
Temp: -100°C to +200°C
Mental breaks: none
Carry capacity: 1000
Hunger: −10%

Mobility & Productivity
Move speed: 2×
Work speed: 2×
Learning speed: 2×

Combat & Defense
Moderate accuracy/melee buffs

Moderate armor
Moderate incoming damage reduction (−25%)

Healing & Medicine
Tend speed: 50%
Tend quality: +20%
Surgery speed: +50%
Immunity gain: +50%
Injury healing: +50%

Marine Trait
TraitDef: Marines — Degree 1

Survival & Physiology
Temp: -100°C to +200°C
Mental breaks: none
Carry capacity: 2500
Hunger: −15%

Mobility & Productivity
Move speed: 3×
Work speed: 3×
Learning speed: 3×

Combat & Defense
Strong accuracy/melee
Strong armor (x1 sharp/blunt/heat)
Incoming damage: −50%

Resistance
Immunity gain: +100%
Injury healing: +100%
Toxic resist: 1.0

War Hero Trait
TraitDef: WarHero — Degree 0

Survival & Physiology
Temp: -100°C to +200°C
Mental breaks: impossible
Carry capacity: 5000
Hunger: −20%

Mobility & Productivity
Move speed: 500×
Work speed: god-tier
Learning: instant

Combat & Defense
Extreme accuracy & melee
Armor: 2.5× (sharp/blunt/heat)
Incoming damage: −90%

Resistance
Immunity gain: +800%
Injury healing: +800%
Toxic resist: 9999
Psychic sensitivity: −1

🔧 Technical (C#)

Classes:
Gene_CorpsmanTemplate
Gene_MarineTemplate
Gene_WarHeroTemplate

Behavior:
Runs once per pawn
Removes old specialization traits
Applies new specialization trait
Applies skill templates
effectsApplied flag prevents re-run
Also executes during save load → retroactive

🔌 Compatibility

✔ RimWorld 1.6+
✔ Safe with Biotech, Royalty, Ideology
✔ Compatible with most gene mods
✔ No patched vanilla defs
✔ Uses only vanilla StatDefs

No known conflicts.

❓ FAQ
Q: Can pawns inherit these genes?
No. These are xenogenes only for balance and control.

Q: Will this break existing saves?
No — it automatically updates pawns when loaded.

Q: Is this overpowered?
Yes — intentionally.
But it’s scaled, predictable, and lore-friendly, not instant godmode.

🙏 Credits

Code & XML: Steve / Valorhaus
AI Assistance: ChatGPT (OpenAI)

Testing: Your colony :)

📜 License

GNU GENERAL PUBLIC LICENSE
