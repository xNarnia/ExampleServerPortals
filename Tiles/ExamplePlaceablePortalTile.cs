﻿using ServerPortals.TileEntities;
using ServerPortals.Tiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExampleServerPortals.Tiles
{
    public class ExamplePlaceablePortalTile : ServerPortalTile
    {
        public override void SetStaticDefaults()
        {
            // If you forget to call this, your entire portal will break!
            base.SetStaticDefaults();

            // Tile properties
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;

            // Placement
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };

			// Allows your portal to display it's stored internal information when hovering over it
			// Also registers this tile to be loaded/saved to the world file
			TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(ModContent.GetInstance<ServerPortalTileEntity>().Hook_AfterPlacement, -1, 0, true);
            TileObjectData.addTile(Type);
        }

        /// <summary>
        /// Prevents this tile from dropping an item so players can't take it and abuse it.
        /// </summary>
        public override bool CanDrop(int i, int j)
        {
            return false;
        }
    }
}
