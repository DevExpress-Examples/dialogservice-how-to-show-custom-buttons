# DialogService - How to show custom buttons

In this example, you can see how to show a dialog with custom buttons.

The **DialogService** class provides a special overloaded **ShowDialogAsync** method that accepts a list of UICommand objects in its first parameter. With this method, you can pass a list of commands that should be shown in your dialog as corresponding buttons:

* **C#:**

```
    var result = await DialogService.ShowDialogAsync(
        new List<UICommand>() { restoreDefaultsCommand, saveCommand, cancelCommand},
        "Check options that you want to enable",
        viewModel);
```

* **Visual Basic:**
```
    Dim result = Await DialogService.ShowDialogAsync(New List(Of UICommand)() From {
        restoreDefaultsCommand,
        saveCommand,
        cancelCommand
    }, "Check options that you want to enable", viewModel)
```