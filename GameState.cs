namespace Tetris
{
    public class GameState
    {
        private Block currentBlock;

        public Block CurrentBlock
        {
            get => currentBlock;
            private set
            { 
                currentBlock = value; 
                currentBlock.Reset();

                for(int i =0; i<2; i++)
                {
                    currentBlock.move(1, 0);
                    if (!BlockFits())
                    {
                        currentBlock.move(-1, 0);
                    }
                }
            }
        }

        public GameGrid GameGrid { get; }
        public BlockQueue BlockQueue { get; }
        public bool GameOver { get; private set; }
        public int Score {  get; private set; }
        public Block HeldBlock { get; private set; }
        public bool canHold {  get; private set; }

        public GameState()
        {
            GameGrid = new(22, 10);
            BlockQueue = new BlockQueue();
            CurrentBlock = BlockQueue.GetAndUpdate();
            canHold = true;
        }

        private bool BlockFits()
        {
            foreach(Position p in CurrentBlock.TilePosition())
            {
                if(!GameGrid.IsEmpty(p.Row, p.Column))
                {
                    return false;
                }
            }
            return true;
        }

        public void HoldBlock()
        {
            if (!canHold)
            {
                return;
            }
            if(HeldBlock == null)
            {
                HeldBlock = CurrentBlock;
                CurrentBlock = BlockQueue.GetAndUpdate();
            }
            else
            {
                Block tmp = CurrentBlock;
                CurrentBlock = HeldBlock;
                HeldBlock = tmp;
            }
            canHold = false;
        }

        public void RotateBlockCW()
        {
            CurrentBlock.RotateCW();

            if (!BlockFits())
            {
                CurrentBlock.RotateCCW();
            }
        }

        public void RotateBlockCCW()
        {
            CurrentBlock.RotateCCW();

            if (!BlockFits())
            {
                CurrentBlock.RotateCW();
            }
        }

        public void MoveBlockLeft()
        {
            CurrentBlock.move(0, -1);

            if (!BlockFits())
            {
                CurrentBlock.move(0, 1);
            }
        }

        public void MoveBlockRight()
        {
            CurrentBlock.move(0, 1);

            if (!BlockFits())
            {
                CurrentBlock.move(0, -1);
            }
        }

         private bool IsGameOver()
        {
            return !(GameGrid.IsRowEmpty(0) && GameGrid.IsRowEmpty(1));
        }

        private void PlaceBlock()
        {
            foreach(Position p in CurrentBlock.TilePosition())
            {
                GameGrid[p.Row, p.Column] = CurrentBlock.Id;
            }

            Score +=  GameGrid.ClearFullRows();

            if (IsGameOver())
            {
                GameOver = true;
            }
            else
            {
                CurrentBlock = BlockQueue.GetAndUpdate();
                canHold = true;
            }
        }

        public void MoveBlockDown()
        {
            CurrentBlock.move(1, 0);

            if (!BlockFits())
            {
                CurrentBlock.move(-1, 0);
                PlaceBlock();
            }
        }

        public int TileDropDistance(Position p)
        {
            int drop = 0;

            while (GameGrid.IsEmpty(p.Row+drop+1, p.Column))
            {
                drop++;
            }
            return drop;    
        }

        public int BlockDropDistance()
        {
            int drop = GameGrid.Rows;
            
            foreach(Position p in CurrentBlock.TilePosition())
            {
                drop = System.Math.Min(drop, TileDropDistance(p));
            }
            return drop;
        }

        public void Dropblock()
        {
            CurrentBlock.move(BlockDropDistance(), 0);
            PlaceBlock();
        }
    }
}
