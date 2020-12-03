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

### To expressions

The following will create a shortcut between `CTRL+R` and the result of the expression `1 + 2`

```kalk
>>> shortcut(myshortcut, "CTRL+R", 1 + 2)
```

If you then press `CTRL+R` while editing, you will get 3:

```kalk
>>> # Below we press CTRL+R 4 times
>>> 3333
```

You can list all the shortcuts available with the command [`shortcuts`](/doc/api/general/#shortcuts).

For example, the following shortcut is defined by default:

```kalk
shortcut(pi, "CTRL+G P", "Π", "CTRL+G p", "π")               # CTRL+G P => "Π", CTRL+G p => "π"
```

For example, by default, pressing `CTRL+G p` will display the symbol `π`. 

### To actions

It is also possible with `kalk` to map a shortcut to an action that can **influence the cursor/editing experience** (e.g move cursor to left, cut selection)

For example, in `kalk`, the action for moving the cursor to the left or right are defined like this:

```kalk
shortcut(cursor_left, "left, ctrl+b", action("cursor_left"))
shortcut(cursor_right, "right, ctrl+f", action("cursor_right"))
```

For the full list of available actions, you can consult the [action](../api/general.generated.md#action) function.

For the full list of all the shortcuts defined, you can consult [core.kalk]({{site.github_repo_url}}/blob/master/src/Kalk.Core/core.kalk) that is loaded by default by kalk.

{{NOTE do}}
- The case (upper or lower) of the key pressed when associated with a `CTRL` or `ALT` modifier is not taken into account
- When pressing `CTRL+G p`, you need to press `CTRL+G` and then press `p`, you should not keep the key `CTRL` pressed.
{{end}}