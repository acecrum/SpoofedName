# Spoofed Name

## This plugin requires [Harmony](https://github.com/pardeike/Harmony/releases/)
Download the Harmony-Fat.zip and extract `0Harmony.dll` in the `net48` folder to your `plugins` folder.

## This plugin allows server staff members to spoof their names.
Use the `.spoof` client command to set a spoof.
ex: `.spoof ace` will set your name from your current name to "ace".
running `.spoof` will remove an existing spoof from you.

You need to reconnect for a spoof to take effect.

## Allow a group to use the command

To allow a group to use the command (such as moderators, content creators, and any other group you may see fit).

Open your plugin `permissions.yml` file in<br>
Linux:`/home/NAME/.config/SCP Secret Laboratory/LabAPI/configs/`<br>
Windows: `AppData\Roaming\SCP Secret Laboratory\LabAPI\configs\`

Change and add what groups should have access to it<br>
Example:

```yaml
default:
  inherited_groups: []
  permissions: []
owner:
  inherited_groups:
    - admin
  permissions:
    - '*'
admin:
  inherited_groups:
    - moderator
  permissions: []
moderator:
  inherited_groups: []
  permissions:
    - acecrum.spoofname.spoof
```

Admin inherits permissions from Moderator and Owner inherits permissions from Admin.<br>
Add any other group that may be needed for your use case (Other staff roles, Content creators, etc.)

(Spoofing should not be given access to non-staff members and/or players that do not need it, this hurts your ability to deal with rule breakers and is easily abusable. Do not allow spoofing to be able to be used in the default group, this gives every player access to spoofing.)