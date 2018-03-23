# Segue initializer with reflection for Xamarin-iOS

## What problem does this repo solves ?

When you ViewController which is connected another ViewControllers and you want to share data between them, you have
messy PrepareForSegue method, because method is full with if-else/switch statements.
Code is not readable and less maintanable.

Your method looks like this

```
public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {

            if (segue.Identifier == UserDetailsSegue) {

                var destVc = segue.DestinationViewController as MyTasksViewController;


                destVc.SelectedUser = _selectedUser;
                var plusBtn = new UIBarButtonItem(UIBarButtonSystemItem.Add, (s, e) => {
                    
                    destVc.PerformSegue("addTaskSegue", null);
                });
                destVc.NavigationItem.RightBarButtonItem = plusBtn;
                plusBtn.TintColor = Theme.GreenColor;
              
                IUserModel userModel = _selectedUser;
                destVc.NavigationItem.Title = userModel.FullName;
                userModel.Token = this.UserModel.Token;

                destVc.User = userModel;
            }

            if(segue.Identifier == AddTaskSegue)
            {
                var viewController = segue.DestinationViewController as NewTaskViewController;

                viewController.SelectedUserToInit = _selectedUser;
                viewController.User = this.UserModel;
            }
        }
```

# This is not the code we like to write, You know.

So now with this simple solution, you can make method which you want to execute while performing the segue, with attributed segueId.
With reflection we track throwed SegueId and then call the method which has this SegueId in the attribute.
So you don't need if/else and switch statements to track segue, you can just make method, write attribute and just pass target
DestinationViewController object.

## Example

Your prepareForSegue method looks like this

```
public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
{

            SegueInitializer
                .PrepareForSegue(segue.Identifier,this,
                             segue.DestinationViewController, sender);
}
```

And your data transfer methods looks like this

```
[SegueInit(TestSegueId)]
private void SomeMethodWhilePerformingSegue(DestinationViewController destVc, NSObject sender)
{
            destVc.Car = this.CurrentCar;
            destVc.DetailsModel = _currentDataModel;
}
```
