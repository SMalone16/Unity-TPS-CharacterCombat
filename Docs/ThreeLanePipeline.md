# 3-Lane Delivery Pipeline

## Scope
This pipeline aligns gameplay implementation, content integration, and engineering quality gates so vertical slices can scale from Hero 1 to Hero 2 without reauthoring the state architecture.

## Lane 1 — Gameplay
**Goal:** Deliver one hero vertical slice with movement + 3-hit combo + signature power.

### Backlog
- Use existing `PlayerStateMachine` locomotion states as baseline movement stack.
- Confirm 3-hit grounded combo in `PlayerAttackState` (`comboMax = 3` default).
- Enable signature power via `PlayerSkillState` trigger (`Skill` input action).
- Tune Hero 1 combat values in `HeroCombatConfig` (`signaturePowerRadius`, `signaturePowerDamage`, `signaturePowerRecovery`).

### Deliverables
- Prototype scene supports movement + combo + signature power loop.
- Hero 1 combat config asset tuned for first encounter.

## Lane 2 — Content
**Goal:** Make the vertical slice feel production-readable.

### Backlog
- Retarget locomotion/combat clips to Hero 1 rig.
- Add animation events for hit/impact windows and signature VFX hook.
- Hook impact and signature power VFX through `ParticleHelper`/`ParticleFX`.
- Camera tuning pass in `ActionCamera` (combat zoom, shake thresholds, follow framing).

### Deliverables
- Hero 1 animation set playable in Prototype scene.
- VFX integrated for combo impacts + signature burst.
- Camera profile meets encounter readability.

## Lane 3 — Engineering
**Goal:** Stabilize architecture and guard against regressions.

### Backlog
- Introduce input abstraction (`ICharacterInputSource`) and keep state machine decoupled from concrete input setup.
- Add EditMode state architecture tests (state map non-null + unique class coverage for core states).
- Add CI compile checks via Unity test runner workflow.
- Set profiling budget and capture checkpoints in encounter scene.

### Profiling Budget (target)
- **Frame time:** <= 16.6 ms (60 FPS) on target hardware.
- **CPU main thread:** <= 10 ms during one-enemy loop.
- **GC alloc per frame:** 0 B in steady-state combat loop.
- **Animation + physics spikes:** no spikes above 20 ms for > 2 consecutive frames.

## Milestone Gates

### Gate A — Prototype Integrity
- Project compiles (CI + local editor compile).
- Prototype scene enters play mode with no null reference exceptions.

### Gate B — Encounter Stability
- One enemy encounter loop stable at target FPS budget.
- Combo and signature power can be executed repeatedly without state lock.
- Camera + VFX remain synchronized to attack windows.

### Gate C — Second Hero Scalability
- Hero 2 integrated using the same `PlayerStateMachine` and `PlayerStateFactory` architecture.
- Hero-specific behavior expressed through data/config + content, not duplicated state classes.
- State architecture tests pass unchanged.

## Execution Cadence
- **Daily:** 15-min lane sync, blockers + gate delta.
- **Twice weekly:** gate rehearsal in IntegrationTest scene.
- **Weekly:** profiling snapshot and architecture debt review.
