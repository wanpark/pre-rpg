using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Rpg
{
    class JobMenuController : Controller
    {

        Player targetPlayer;
        Controller parentController;

        JobPreviewView previewView;
        JobTreeView treeView;
        JobSelectView selectView;

        JobTreeItemView selectedItem;

        public JobMenuController(ControllerManager controllerManager, Player targetPlayer, Controller parentController)
            : base(controllerManager)
        {
            this.targetPlayer = targetPlayer;
            this.parentController = parentController;

            Views.Add(new PlayerPreviewView(Screen, targetPlayer));
            previewView = new JobPreviewView(Screen, targetPlayer);
            Views.Add(previewView);
            treeView = new JobTreeView(Screen, JobManager.Instance.Jobs);
            Views.Add(treeView);
            selectView = new JobSelectView(Screen);
            Views.Add(selectView);

            JobTreeItemView item = treeView.ItemView(targetPlayer.Job);
            Select(item);
            item.Active = true;
        }

        public override void HandleInput(InputState input) {
            base.HandleInput(input);

            if (input.IsNewKeyPress(Keys.Up))
            {
                SelectUp();
            }
            if (input.IsNewKeyPress(Keys.Down))
            {
                SelectDown();
            }
            if (input.IsNewKeyPress(Keys.Left))
            {
                SelectLeft();
            }
            if (input.IsNewKeyPress(Keys.Right))
            {
                SelectRight();
            }

            if (input.IsNewKeyPress(Keys.X))
            {
                setJob();
            }
            if (input.IsNewKeyPress(Keys.Z))
            {
                exit();
            }
        }

        private void exit()
        {
            ControllerManager.Controller = parentController;
        }

        private void setJob()
        {
            treeView.ItemView(targetPlayer.Job).Active = false;
            selectedItem.Active = true;
            targetPlayer.Job = selectedItem.Job;
        }


        private void Select(JobTreeItemView item)
        {
            if (selectedItem != null)
                selectedItem.Selected = false;
            selectedItem = item;
            selectedItem.Selected = true;
            selectView.Select(selectedItem);
            previewView.Job = selectedItem.Job;
        }

        private void SelectUp()
        {
            MoveSelection(-1, 0);
        }
        private void SelectDown()
        {
            MoveSelection(1, 0);
        }
        private void SelectLeft()
        {
            MoveSelection(0, -1);
        }
        private void SelectRight()
        {
            MoveSelection(0, 1);
        }

        private void MoveSelection(int dr, int dc)
        {
            int row = selectedItem.Row;
            int col = selectedItem.Col;
            JobTreeItemView item = null;
            do
            {
                row = (row + dr + treeView.Rows) % treeView.Rows;
                col = (col + dc + treeView.Cols) % treeView.Cols;
                item = treeView.ItemView(row, col);
            } while (item == null);

            Select(item);
        }

    }
}
