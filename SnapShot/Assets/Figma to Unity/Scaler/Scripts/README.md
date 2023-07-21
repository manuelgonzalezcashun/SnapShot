## Proportional Scaler

A helper script to set RectTransform anchors for proportional scaling.

### ⚡ Quick Guide

1. Add the script **ProportionalAnchorCalc.cs** to the RectTransform you want to scale.
2. Make sure that both of the Targets fields are filled in.
3. Click **Set as Anchors** on the script in the Editor to apply the proportional anchors.
4. Remove the script.

#### Notes

This script requires two target RectTransforms:

* `currentRect` is the RectTransform that you want to scale relative to another object.
* `anchorRect` is the reference RectTransform that you want `currentRect` to be anchored to.

By default, `currentRect` will be set to the RectTransform that the script is on. If available, `anchorRect` will be set to `currentRect`'s parent. You can change these references to whatever you want, but objects will always try to scale with their parent.

### Stretch Scaling vs. Proportional Scaling

In Stretch scaling, the developer defines the margins between the child rect's sides and its parent's sides. Those margins remain the same as the parent scales. In Figma, this behavior is called *Left and Right* for the x-axis and *Top and Bottom* on the y-axis.

Drop shadows are an instance where Stretch scaling is appropriate. You can see here how proportional scaling (Scale) causes the shadow to appear too large or too small at extremes.

|                                         |                                      |
| :---:                                   | :---:                                |
| ![](/Docs/StretchBehavior_Good_250.gif) | ![](/Docs/ScaleBehavior_Bad_250.gif) |

In proportional scaling, the child object's normalized position must be defined relative to the parent object. When the child's anchors are set, the child will always take up the same proportion of the parent object, no matter how the parent is scaled. In Figma, this behavior is called *Scale* on both axes.

In this example, there are two sibling Images, an Icon and a Border. The Icon is smaller than the Border, but the two should scale together. Here you can see how the Stretch behavior deforms the two Images at different rates to keep the Icon's margins the same. Proportional scaling (Scale) sets the Icon's anchors to correct this.

|                                        |                                       |
| :---:                                  | :---:                                 |
| ![](/Docs/StretchBehavior_Bad_400.gif) | ![](/Docs/ScaleBehavior_Good_400.gif) |
