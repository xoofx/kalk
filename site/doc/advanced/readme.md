---
title: Advanced Topics
---

## Configuration

By default, `kalk` will try to load a configuration file from `<HOME>/.kalk/config.kalk`.

This configuration file can contain any multi-line kalk code.

For example, the following configuration will always import all modules when launching kalk:

```kalk
# .kalk/config.kalk 
import All # We always import all modules
```

Depending on your OS, the HOME might be a different folder. For example, on Windows the configuration can be loaded from `%USERPROFILE%\.kalk\config.kalk`.

## Keyboard

You can configure new keyboard shortcuts directly within `kalk` with the [`shortcut`](/doc/api/general/#shortcut) command.

The following will create a shortcut between `CTRL+R` and the result of the expression `1 + 2`

```kalk
>>> shortcut(myshortcut, "CTRL+R", 1 + 2)
```

If you then press `CTRL+R` while editing, you will get 3:

```kalk
>>> # Below we press CTRL+R 4 times
>>> 3333
```

You can list the shortcuts available with the command [`shortcuts`](/doc/api/general/#shortcuts):

```kalk
>>> shortcuts
# Builtin Shortcuts
shortcut(alpha, "CTRL+G A", "Α", "CTRL+G a", "α")            # CTRL+G A => "Α", CTRL+G a => "α"
shortcut(beta, "CTRL+G B", "Β", "CTRL+G b", "β")             # CTRL+G B => "Β", CTRL+G b => "β"
shortcut(chi, "CTRL+G C", "Χ", "CTRL+G c", "χ")              # CTRL+G C => "Χ", CTRL+G c => "χ"
shortcut(delta, "CTRL+G D", "Δ", "CTRL+G d", "δ")            # CTRL+G D => "Δ", CTRL+G d => "δ"
shortcut(epsilon, "CTRL+G E", "Ε", "CTRL+G e", "ε")          # CTRL+G E => "Ε", CTRL+G e => "ε"
shortcut(eta, "CTRL+G H", "Η", "CTRL+G h", "η")              # CTRL+G H => "Η", CTRL+G h => "η"
shortcut(gamma, "CTRL+G G", "Γ", "CTRL+G g", "γ")            # CTRL+G G => "Γ", CTRL+G g => "γ"
shortcut(iota, "CTRL+G I", "Ι", "CTRL+G i", "ι")             # CTRL+G I => "Ι", CTRL+G i => "ι"
shortcut(kappa, "CTRL+G K", "Κ", "CTRL+G k", "κ")            # CTRL+G K => "Κ", CTRL+G k => "κ"
shortcut(lambda, "CTRL+G L", "Λ", "CTRL+G l", "λ")           # CTRL+G L => "Λ", CTRL+G l => "λ"
shortcut(mu, "CTRL+G M", "Μ", "CTRL+G m", "μ")               # CTRL+G M => "Μ", CTRL+G m => "μ"
shortcut(nu, "CTRL+G N", "Ν", "CTRL+G n", "ν")               # CTRL+G N => "Ν", CTRL+G n => "ν"
shortcut(omega, "CTRL+G W", "Ω", "CTRL+G w", "ω")            # CTRL+G W => "Ω", CTRL+G w => "ω"
shortcut(omicron, "CTRL+G O", "Ο", "CTRL+G o", "ο")          # CTRL+G O => "Ο", CTRL+G o => "ο"
shortcut(phi, "CTRL+G F", "Φ", "CTRL+G f", "φ", "CTRL+G j", "ϕ") # CTRL+G F => "Φ", CTRL+G f => "φ", CTRL+G j => "ϕ"
shortcut(pi, "CTRL+G P", "Π", "CTRL+G p", "π")               # CTRL+G P => "Π", CTRL+G p => "π"
shortcut(psi, "CTRL+G Y", "Ψ", "CTRL+G y", "ψ")              # CTRL+G Y => "Ψ", CTRL+G y => "ψ"
shortcut(rho, "CTRL+G R", "Ρ", "CTRL+G r", "ρ")              # CTRL+G R => "Ρ", CTRL+G r => "ρ"
shortcut(sigma, "CTRL+G S", "Σ", "CTRL+G s", "σ")            # CTRL+G S => "Σ", CTRL+G s => "σ"
shortcut(tau, "CTRL+G T", "Τ", "CTRL+G t", "τ")              # CTRL+G T => "Τ", CTRL+G t => "τ"
shortcut(theta, "CTRL+G Q", "Θ", "CTRL+G q", "θ", "CTRL+G J", "ϑ") # CTRL+G Q => "Θ", CTRL+G q => "θ", CTRL+G J => "ϑ"
shortcut(upsilon, "CTRL+G U", "Υ", "CTRL+G u", "υ")          # CTRL+G U => "Υ", CTRL+G u => "υ"
shortcut(xi, "CTRL+G X", "Ξ", "CTRL+G x", "ξ")               # CTRL+G X => "Ξ", CTRL+G x => "ξ"
shortcut(zeta, "CTRL+G Z", "Ζ", "CTRL+G z", "ζ")             # CTRL+G Z => "Ζ", CTRL+G z => "ζ"
```

For example, by default, pressing `CTRL+G P` will display the symbol `π`. 

{{NOTE do}}
When pressing `CTRL+G P`, you need to press `CTRL+G` and then press `P`, you should not keep the key `CTRL` pressed.
{{end}}

