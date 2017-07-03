﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Blockchain
{
    public class Chain
    {
        public List<Block> BlockChain { get; }
        private IBlockFactory _blockFactory;

        public Chain(IBlockFactory blockFactory)
        {
            _blockFactory = blockFactory;
            BlockChain = new List<Block>();

            var genesisBlock = _blockFactory.GenerateGenesisBlock();
            BlockChain.Add(genesisBlock);
        }

        public void AddBlock(string data)
        {
            var newBlock = _blockFactory.GenerateNextBlock(GetLastBlock(), data);

            BlockChain.Add(newBlock);
        }

        public Block GetLastBlock()
        {
            return BlockChain.Last();
        }
    }
}
