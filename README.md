# Rikako Title Map Editor

Windows Forms helper for previewing 16x16 tilemaps from simple, hex-coded map data. Load a tile sheet image, paste or open map text, and page through generated previews to verify layout before committing assets.

## Requirements
- Windows with [.NET 8 SDK](https://dotnet.microsoft.com/download) installed
- 16x16 pixel tile sheet saved as `.bmp`, `.png`, or `.jpg`
- Map text that lists tile codes in hexadecimal (see format below)

## Getting Started
- Build: `dotnet build MapEditHelper/MapEditHelper.csproj`
- Run from source: `dotnet run --project MapEditHelper`
- Publish (optional): `dotnet publish MapEditHelper/MapEditHelper.csproj -c Release -r win-x64`

## Using the app
1) Launch the app (`Rikako.exe` from `bin/<config>/<tfm>` or `dotnet run`).
2) Click **Load Tilemap** (or File → Load Tilemap) and select your tile sheet.
3) Load your map text via **Load Map** (or File → Load Map) or paste it directly into the editor.
4) Click **Generate** to render a preview. Use **Previous/Next** to move through sections when the map is taller than five rows.

### Map text format
- Each row is declared as `Row { ... }`.
- Tile codes are hexadecimal; the first nibble is the tile’s row in the sheet and the second nibble is the column (e.g., `0x32` → sheet row 3, column 2).
- The preview uses up to 24 tiles per row (`TILES_PER_ROW`) and shows 5 rows per section (`TILES_PER_SECTION`).

Example:
```txt
Row { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17 }
Row { 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1A, 0x1B, 0x1C, 0x1D, 0x1E, 0x1F, 0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27 }
Row { 0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x2D, 0x2E, 0x2F, 0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37 }
```

## Project layout
- `MapEditHelper.sln` – solution entry point
- `MapEditHelper/` – Windows Forms project (`net8.0-windows`)
- `MapEditHelper/Mainform.cs` – preview logic, tile parsing, section navigation
- `MapEditHelper/Mainform.Designer.cs` – UI layout and menus
- `MapEditHelper/rikako.ico` – application icon

## Notes
- The preview clears to white before drawing; only codes matching tiles on the sheet are rendered.
- If a row lists more than 24 tile codes, the extra values are ignored in the preview.
- About dialog reports version 1.0; update it in `Mainform.cs` if you bump the app version.
