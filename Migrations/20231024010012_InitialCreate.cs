﻿using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BE_charity_direct.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Charities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    imgUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    uid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharityUser",
                columns: table => new
                {
                    CharitiesId = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharityUser", x => new { x.CharitiesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_CharityUser_Charities_CharitiesId",
                        column: x => x.CharitiesId,
                        principalTable: "Charities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharityUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    charityId = table.Column<int>(type: "integer", nullable: false),
                    userId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Charities_charityId",
                        column: x => x.charityId,
                        principalTable: "Charities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Charities",
                columns: new[] { "Id", "Description", "Name", "imgUrl" },
                values: new object[,]
                {
                    { 1, "The Red Cross is a globally recognized humanitarian organization that provides emergency assistance, disaster relief, and education. They offer support during natural disasters, health crises, and armed conflicts. Their work includes blood donation services, disaster preparedness, and aiding vulnerable communities worldwide.", "The Red Cross", "data:image/jpeg;base64,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" },
                    { 2, "UNICEF is a United Nations agency dedicated to improving the well-being of children around the world. They provide lifesaving healthcare, nutrition, education, and protection to children in need. UNICEF works in over 190 countries, striving to create a better future for every child.", "UNICEF", "https://getinthepicture.org/sites/default/files/images/partner/logos/unicef.png" },
                    { 3, "Habitat for Humanity is a nonprofit organization that focuses on providing affordable housing for those in need. They engage volunteers and partner with families to build safe and decent homes. Their mission is to address housing poverty and promote stable, self-sufficient communities.", "Habitat for Humanity", "https://www.irchabitat.org/wp-content/uploads/2023/04/cropped-habitat-for-humanity-logo.jpg" },
                    { 4, "Doctors Without Borders is an international medical humanitarian organization that offers medical care in crisis situations. Their teams of healthcare professionals work in conflict zones, natural disasters, and with underserved populations to provide vital medical assistance and address health emergencies.", "Doctors Without Borders", "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAOEAAADhCAMAAAAJbSJIAAABIFBMVEX////uAAD+/v7vAADrAAD8///yAADoAAD6/////f/+/vzeAADgAADkAAD8/v/bAAD8//vVAAD+/vn2AAD/+v/3//z//Pr7//jgjIf//Pj/+vv34eb2//r46ejYQUDkj5HfFR3heHLlaWnsw8Xorq3aVlD/9Pfy0dDz2Nbpqqb36OXsp6jteHLpSEjhZF/4xcHXLyzhgHzonJ/VYVjcT1Haamvqd3zpanbon6bfOD31zMX94+zmtbHUgn/dlI7agorUIxPwtLfUJSHlLDD12dLznqDlvb/y0dTks7HojpLklpLjfYDzvsHdTUvcPjjx0sjiMj317OTqwLThVF3kjYDldGrRABfWMDvWbXHqUk+/AADeXGDIRFDoXFXXMxrcfXZr8bJyAAAc1ElEQVR4nO1diVvjRrJvtbrVh27hGwwGPMaYhAEWJjs8XnZg2JDhmCPZ7Nt987L5//+LV9Uyxock2wwDZD5Xvk1YsKX+qarr7hIhC1rQgha0oAUtaEELWtCCFrSgBS1oQQta0IIWtKAFLWgeok+9gK9OlCqa0lOv5KsQoNJBVJJRheuE8Oip1/PwJBUlEZHLPU60kip46vU8KFFkYBJRnux8F3rf7/YkJfxbktR060nOX8aC2ZZw4q4Mkm9pM1KqqdbyYs8Xtg0QmRV3E/UNAUQeViRph8yyHZtZFmNWWJfqqZf1gAQ8XCH7viMsG3kITLTFwTdlHCkN1F+YJWzBgH2WwRk2jar5JmByVVXkELbfEIHCuZQqUd+G7QfjRzbEKEKQ0/CCa/1tIOSSbPu2LUYBMueIVOQ3AZAo2QxBLEdYaPu245ZW1LeAkNKEvBiVUAPRsvwtqb8BhLDR+Lk7iRC1zQGvfAMIAaJcF1kALfaKfxOaBhDEViYPrUPwvv/0ADl4n03Pz0b4A1H0T2/ylaT8r2N6dLAPL/k3EO1zVSGvnUyAtn8svwFrEfCV/4qdbE0jtnAf/tkhcsW3WYaQMiGcsFOexx7ShEottY6enbu+xjIgOkw4q0Tp2S5BjVnljWqkAhU8s80ryT4o0gmIECmKE0JnQ0hNEhKMp4T/U648s2ykJv/t2JMI2ZJwVXV2hNz80Ptxvd0sPzOAlPwN490JhBZbm5Zs00EQ8SThPCKcLO+stlqx7YhdIqNK9HwgwsPfZxmqlAm3kbfK298rqiGAhB8am/tvXJPeYcz2a1TS54WwbY9pGrNQtkNyZI3ekuZSStLdOXTBZXAY2BwHvmjtSXAjHhlGAVFgQiyWxDhCtspzLcWgsiGbJ1dhaNI6NobMNihgYXsX0fNKRFK+449qGgaOeNik5SyEwLgg0HWlOelefowZYJvYwWBlnpGUIkOS1VExBW6E51zW7xDSwb8CyqUmsrR55XrAsCxfwYp59RkBNPFh0xt4pkZCWXgeaT2Uo6GoU8ByUBWByaufbngCZZOBYE5EJczylwl/SkTjBKsnfxnZg0thF5RFiQ99RCFChVavuX0Y+g46PaiPJlkIV3DOms+Jh6gTdTPGRD4oChA72/b2iR5ZopJBFEgORu/gLZi8Sb6N084z42Ek+UWIyhDNIGNnPalGEEYlmUhOLt61PDQj2YHIEAlr9zkhRJ+yEfHmmRA28M9x4qaMjLofgOSw97ZqYcgwEw4xxzSEzA6fElEWBcDF83d/r+288L34RCsMDwZmD9ixue/7sL1AjG1n0oWdIFusPTWiCQKLEXHYZ6q3THkJmacroE1pAD+iXQB3JQeYPWYQsW4l/IunBjRORtuAtFYBpkwDA6zjA+St/dCDrYmacyrrUgkVzGHWj0+NaIKwBgwIEx0opcv4myjdez7DkilavhkRghmxbVEbufjTYBqjtI4P8GjQZ2K31vIQmG08l3Hn/I5nBvutpAI423UP15p3FybPJ1gEPgYqakDoo0nv4MxnYqrZMxBBKNGAMHwcfryx3QPfR5kCOSDjOig9m/oV2MV6HUW00V4NgSn+dMOOMslQByGTw3DjpEckgdiwzzazn8v6+dQ+qFJlrjc3QuGgS2ZNtXt9HoKn4IVH2128hgzUcCZKKQm/emqAt3l7XNX5foiRFPwD1n8W3YK2ITw8AHSSg5tQiSpUo90ZJEA+/dQj9O4mTwIQpJNyVSay0X7vW9NE0053nLB8E1yEe7XN26YU4yToKKpoDv/GHNbFVcv1vZdc6+Qp9Q1YiUoZ4tlXobCWpvINEYolE2KJ+Ld2k2iihqOsiCrsreKEbv6362P8KOKefNqOB0qrpNL+6GMo5M+EEHMV7msUTSJTXUkH1wKDA056/fqVi905qGmX7Fainq6DDO/Ll/dDzOJDTDBduaAUe/76dZPwJCkDv5IkGuahlKSz83sojKV0MBoDL2fjKcofgY4CRWH7keMbD8x6/vYzth4tP36KCW/14IKDXqF3FJXAJYqUwpR3b2c1ZGMekO2fkHry2K2OpUCXYcN0tltiySrUL2bPQbwAvBDhDz93OBqBQfxnICZlLpWUfPnyvZdxLccKG49t9mHvgePJe/uxjVFDodMJ7LMd0J/u27Ut+KqMNHxTDV2KygYqToj/Q7yUmIg34Am947MWeR4MIQTxF7se5ixQ/JxCGyGWhPd5G3zNspZSU3Be6QgP4WF1L9+GoIiFxTLMKLOXYghBH6HV0eSpNdwKAiN98trLKDmNLMwyqtPy/dpmlQzluqmpNXHKI60Cwvn55ZmwCi4GbgG75BX5KABhVRUVkWAnnhISoSZEmfPc/S1wNoP+BQZApS5XowizN5ct/3azFiBsEf31K+ap3gs4aa5hurM4o+Rg0sbzrmDr8XqJjlwG6zGRQt24VXsDe8+3c7pV7iBa4uUjdD0Y4QJ9vu7ZxvMsWpXNHC/81zEBuwBBFR9J0qfZYa7P11qucEBVYWN4EUATQR6S6GsCNNKlOdjj7kaIQjMhUUb/YR3RMbGQCDeuMcdNjRdN+2cxNOWaK3DJJKYWfWvKRh4mJ+x8NYR9zaAhMiLHv3qZeeqBMDmWEADv5rTD5SAKord5HAqxUZpabAnfyXxSuXx0dr5Wf1W/ElYF+dy6cQGCU7AqBr63t/f3ppQJV9HwNTBwL4PmBMOwFnpGdc6UAri78m5ePfJhEIITcvw67ZJlExbZrACDBQdC2doF6H8a0BETTWnAOQZEmL3Bz7GpYdYY2Xb4lXhIsYjUkHzzvchVeDb6xwwC+/joGEx5NK70tC6rMuzI5sGem0bHcyDD/6HXZ/vnD8vE/rXALmNecPN9kXk3mpC5N+1Epp3dfYi36wk057rRPgTNyebZe31CTeqA0/7zA8f5tzl5uOrx+9Cxs/Muhh0gdCxcW8auJo7pmrFL0IiTzaNQFLt2+QDTJyI+Vh/YHqJ2UKghPqz6AI9l1msRIWzO8Lst4JKiyajv2Gem7O67vrWExal52WcAYiLOf3OSBA+LkEYrKtBVcnHjTuwb26garNZjksHd26mTCYeD8oBqcCUlhP8uBodzgrPTJh2sxjmW//oEe1MeloWSNpJILv/u54RGJo0NOMP9C8wBTvSiYTIJY4Z9V9iOc4/dB4RiA8rbXT+H5VD1kBApbKZEkuaRL/JiP9Me4u+1FaZaGokeT75HvMTJy1UvrcqwmSszw4QajHmXHcID8GKVejhNg/yo8noN5RPzYuN3TjNlTrx/TniiTXJs4kSslskBsE/gFrbmqswM3YOxs52IyCStKT9QXTiQimO6q3oZjqTlB1beKG5m+2+36+mzyLmO7sV9yze3CsUTjKDaLO/7l0W3gL3O9fxHVcEXUaDdX7ZyYgdgnu1Y4Q8fhlqbsiiKyKdVca/th0f7gO/h5y1pqpG59+DYs6noHLxFN4uia3y+6sEm8LPuDobRj2FrgGqrFt1dRUmF7IT3MhAmGb7fBQVWqY/dY+BI4C8x9yglnaNFDOM2ENDmrudMOFf9GNy2/JtrPLXNIxWkQVHm9Sl234EuXr2PFnVEWPsEGizRUpKRG4wkQrADorlMdGlmhBCqyhWi1sLJ/YdmCdvqrNBo7vEv0mwtgK7yERZIZ61w20IwYYnWZZ0EGTkLZEBSTbAXHN3fi+0j13Xfl/TsPKwGmvzSyuw1Y8yH0C/e7oDoTHTV0SFPbQw6Jb8WZWBGyXgS/t4pTitIu8RGSRFewlQr5582L7+PYUV4qLo2u6qhAekdikwPG9a4FL6+1lxWVDAm98hAnclD8GplufNmnr3ovTgmstzgdIBwqPtPRqADo277uzPXhzjONyGYE8+4D/FxV/a9iX6XWw64RxcARGPwIG/vnGYFCVeNSma6Fv0QVe68mDFXYYP30gVniIKWGt5u/RAAHmRj8+BF7Ak8ES9Q12OWwPZP7/rE8whETCWKXMdj+TPToIXG2vFqTTC8w0+0An6GDrDx4uKVt0Zys7VgfMgGMxYu1y6aTDfscVAvIzUmCEpoEGmJSUfSO7n6jx9OXsZmu7yxMm0vUlIu8SOfLY0GOMx2MMku3L9q9FNH/JYycE9VCTndC5n/Mt/fMFw+BP+yoDCF7BDhQYOPlew5Vmzwh2Z7vxULhhnKcYlHaW3AY5iW8wfl1Mba0DgPUYG+PaWyEpWUHuET+AVlSbf/CSu34q7MvwE4Hiv6iDlOQdWbCe9AEdPHMfxNcI05aZ5cITosm8ND8scRYvXtVJZ4EUIQdEmC70KMVsZsIFi/98eg9HVAo2qk+h9P96AkjUtPGCFu8Uq+kGBM0CBXXn7+2Gatbc2NOIKyG75Ss3115oO5cYwsmfaVCYTgYh0RzFAWQdT8AzZPmjUIvA6KJxoN7+YDGfQh9P+rG1KuVJTsXLrmgYB+P+b5bdm0f+KnG5oAY7C+1LFGARVnbdCQaS48quhIRw2scvfaV7EvZkkM2KEurkzhTJKfwM1ONR6uAmTCB/csPNziUo3pYtmQ6Jh3/uEK8w0IUOOklBRP20GXoOvBU1u6e/bMhJfC3/uFRBqrbfAYlDT7iTdPr8IQnEZwHGdw222/y2XRMBzQBRGJdnwr5aG15LfAr3fCmwvJg5Wxcz0UnLUyae67WAhjptfHWSVy2vkISiOyFS4JMcxDrIyvHoNzEnBU9hCxKbPvfmuF8IGlaYWDIUndJqVihBKWTWqpow0+4S+kfeOtnoP6aUQNOeoxwEr58pUrjClChI7wN0k0xTWk5im+DIdaNTD7AkICLpLGbW5YR/SH2nvXNwqT9QvjMyF8V3xILjWpEXlrgtWlf/Z4wOsnJqYeBGdag+3Gs2WSdNe90ar2DZ/u3af9dy9dJ80ZCEy+eEfnEN8FSSVIIjTn9dPfXFACg0vPEVa+MtnmKUso89+xHPZ2rck1aE15lxQx/bBalyUvU4KFGVMKur248I9n7R4EiLFjG9YwO0QfoqTkCmw+bs51uaZePjusO7JfkeneN63wdfAqdjSPKmUKgcvon7WuUhCE7mdsA3GGEdotMluWz9QutjyUviU7fNchSkoV1dEEvay10FkRWC6/D0JrneipJXDakPsi7pEy7LwSBJVjFWXQ44G8OAxxAaZR6Q5hjfPZirMU5IScgm2D6K/OabkSYbBd2fwOdp45fIHK+V48FFcy2/UfuX1ZdbexhVmZdt+7P1QCjqqAk60bz761Yn3CH/zrWc9rY3mH8xsnfgfRraqswEPstHfD1M24Xzr8lg7IDG0MWByi/ZbAkR4lRQPwyY5XwS0cvzCYMytu8BmlNNVb9YNPHHZBFcLznRuQWUfcUzKHiP08XMrLo75bMBb6Ua2w/eX4tceyzvqCxF0SPcfkObgekVW44vLBnpe2lrKieuQMhN10YPGnp6N0Wp0b/aCxIuR6zzfFpTQGH6od2o5wpZ6jlQdPM0cl3dz5GPZNHrr7X8ZDWE8Mkd38zTYBuBngCnBysteviGU6GLX58tBpAim2TGOesO65/9Dfw94iG0vOPjgnOP1uPnim8F7HwmH7rCDLIoR7MWc+1kDccu3C/pmpBArABPjC/Z93mx2CG2l+hDqAb23HPkhiZtyDK3ScOCeZWHBpTMsuh/fGl0YkGDX5b/Z/6kBgy5OAzD2F0jzpBPAZ/9rOq9vb3ul9ausQWjaxB/pe+y/dMGHr1S9NUBpRFGgO2ovPhVCjxuOV7VhMde3f36+LpxKQ47yqXR7ZpgPS9CG7n7eXzZMa5KpmJvxopGjEebDjiuJ2CWStd0wy2z7pyH8m/xyUG3LNn6mX/47EEuYx/NY/jsH9KCeKDtHMAJEaK/D57VCwKV6w8WdIpks/9c5gNALyYj4e4oLcvUvsDU/U6HOdnYdmUVWiQT5N/Fa4TzBI+GMywT8KMedG4ARW5LI34z60TarECr/faXIa6UhjOHmPCb7YXhcFYP9Qf85ippjlLed4g0E9AQUQBUXiE/DdmUIlVNmWCA+3ezJNTd5rGAGuhFPNqxFvt3xraTZDzC5lTrkC/Jaoaeoy+YIKoZhn2VOPBOODDHdPOkSambZzKpYBPqSKLBFy6rJZW0JweidV2fZea3IS/5L2Z+StB1ix42ZU0CcQ2utVTng5aSj5ZQgjEp28Ec7sfrCNCajxOLK/ei1fW+KP/nDv7LsGsO7aLHkY9orUowpINblnp0IjwrJ9Q5KTt/5kvjUHHHoA3lbu7BJOuuCr+2sQRuRCNMyooUsxpT2YuV/YsSeproJ8Xr81DYNznGWNeZ4moQ2yy5jP2D4P8jwCIzeS7NrTehSZFXbueZakX7nSUkH8cCZMc9o83mKN5ExnAWt3bM5Y+OK3tJEp0ytA31c246z5RKMI2ct74buFCDpNv9xD/yUtQcyEED/mLlezYnuK1Wl5ZRq2HOb/WNCwgSfxyLaY6lmIg3viC1QSyIok2Dg6p6fv+MzelZmTO6mSKqK3rXC22OWlJNcuYsVgQxT3vIEY/+1+rUJUl2WFk+tV07U0pxcsLHGORz4zEAbgVrdZmr1HmVgnMtc7TzQNmp5f3BHGnH/NjdDcj2vQnxevBTPx35wtyYx9xCO6mfsr0bzVXzH2pLqbmU9igJB8nvJ8hf2v+cNbUwWhcusQT8vNeiJ5BKB1AFFZ5slVTcnJgCu2EPaZzp8syHXEt0SxlLJ5h2QoTBlihe78szsn5+4QirCXIzmgH8neaJn1CniVX1+MSGuCh+n3zelK5nvrn+azh0Z7S9m58ibznzMjZP/OExxaJu2R05a20+Kq4MA55wdZUsoERi/C27gucG7zIcroIK2M35vauf5MhcSjc7+Y+EGqfIQN2QkzZhJiKjU8PAFdGMw32oya9qXjljlrdO9cl3A7ebUeJU/HDswy2+tqnnuePtJ8Iwuh9+K0w4lp+CjPk6bA0+DRhv8l7MNyPOZnsm9QJkcTvjv46Dr/qDJodJH2BGJ1HaNBxtzvdz6R2yPecwmpaRnAMuUXIbSsHZIpdhDl0HNvQjaAibyehxDi0qZrENrMmBfmn132wIhicXgOaHcISfxllR50x2JVzfZTIJpazXIzX5Dcud5YLonTMX3YPSDCdxeEy0gpda/hiXCXD8Ka+2TAGEKxYw7+ZFw+0Bdexiwv2z3OlVLsSPs+LYowP9zY5MA+3sCek+lFzwyC4PsnP7/f0zYIimNgCFrdzkojmNQcFAfsr2eJh2DvChBSso56Xfgfd+pE3x5DuVcwbxB+EPl5CmFSrsW5E+DQIchchsGntKw6YRZCx2rl1vpNIIwn9fcvOJejfLtHvkLr4JOXH+dia9y0PA1ss02pMjv1IKJdy97hIj8hgL/fjv99AtJZSkrBF57XBoSK+7lRIAYZnrf295wR8rerDSOV0y8re5ksxEf3RxHCTz08SQv7rxx84VgBE/B+znDWUkME8N51yZpbqGp9p0YyE906qJLDvK+KMG8kabrfzN5TD3AcHS+wPbnPsAq7xOL9LU62Q7toigfScUbahNKgLumxn72J0QPezG1b6tv1L8V2R91w9O7p6bfw1THWK2LsxCvE54TNTDUaJEru5UxOcmzf2peFLaAPSAEJl4bvjnvS+76Nw0bbb8xEsSl5k98zOjtMVolsuSKb/eiteCR6pHfplUnNxKeOyRXh+Ybw0gR7J2+n52uwg3wzU2fwQJGP+dxnVrwcPdJLykorm56VNs8Z675xjeuT7TOsh05BiH+MK1k9ZJxX5ZZXNIVHtB9rci5PiInHHDOweb8H6CR5uYf4ppZJkO0bJMpQimCsyU2RgsKXPz0SwqQUrZlGDeFg9z9XVbL53ndmOkOO37quZiWgOCcnhVOwGPv1saYgUR51sIHZDy8bBM959l7gHJ2p6AwJcUYaevLck+IJb+XnrrETlrXyz2Q8LHHwTa9braPr9GULnXUxe7lJOGKT88m2dYjxyInI34YCdJsTXzySlGp0H/FwFI+kVGumYDhLMdYUNRzvHGfFjRpEM9VT7hU8Jwwcbo4zXaGvQLAcAv5HRYF52nYxG+wzZ4ZNiGpW+Id8Mi2EtpB3/fzuV9vyXkDg8KU+5zzEdSOR5EN/etEMWdP0hEL4+TjDFtIgqCj+OsvSmOF6jLkb54/9Rp0kKJOLG79fbpqKD3P+NnMvm2BZJm0hHjcun4qsiMVxHGF5eB6NysdBeNsEEvBPG57VH406pSqatie773/WpMqjDL8EpwiR15lijvy7QoukK/KeMfv9EJL6O9c2TfNpAmgKQssKN7Y0iajSjckOIa2jiGyOOwt2OnTFrXUkHpY0J7Yeg4e6SoNIkp1w+hDOW3SgXrxak5NAQvQM2rc6cc0gSXQ4agvNrrXNecJHfv+hLIECPX7rstz54WN8sJn/tq0k9lxUIQaXNCmNX5NqJQ/GUqQoHMw7qKN8PqaGobRRJr3PmPCeYfS7GTjnftzkZKVRCvBtuKRR+9/6yngWjFeCejhmC4GHrcuIBLRS3Bf1wPiwvk5qoekdnqGPBed6/HsLpKxBowjzO/pHT4Tdu6Gc6UODP5IrNvqaGVu0tiP4YBLIqUc7H5CCiPJmazo0My8Fz+36n7vYW6xxFGeDg6eHxwcvtQKNqsEC3iIEY39XO0LXgYnXJ5I8VjA4RBUp629maIs3h5IsFh71iFETXCdVLZdvfHMi2AtXmySJVHR7MIM2yOuBNkYD771/iRWogkOlX4u0xoNN02NAiy3ZvvuqR+rUhEk4/qFUw8gIHg+40HZ80qkSHJkE3q2p9NyN93AsF9xPWo0S/dgDYwl6aiRmzgxMZFZ81ZSlhkzSqV0K55xYrD9pBjm53f0V35ICTwC98M+3dXjH8Xa74PWUdSV4Ch5GDRIXwRPGu4GNFOLgklsCDM0XI29zApC+54jwakty8un/yJbr9NNX8UZXqid8d6Eskd+LWOeY6p0IdxI+tEZKurE90u8iHJw6Cwb1982rw1hs+GZks8O8jWWCbw54Knxm3splUWUU42CvtZ0Aswe9gDis7a0z5rnaPvbfOL4Q6SHyJeS++5eulGAz5RMiBGOxJYpm3TP2nxM8lavv+l8AoQqFGK3VCDP0SZhxC/30h7fRA3tbDyoFrTNfn3Bsb5iRsO9PvrB9PFXd/+jtD9h4Exc45ubgkvCPlnM6aR+XUCn+kdF1bJtDUv6LY5JRm6e6ERe4CA44M95RF/b4I6WzCwn9rC0xWYHGneR+7mLnw8Tr3CjysGAgq7C93Z6EJ1O+T1PBQxPHl2GcZXSuWP4fXZwKhkPux76D3d9erpA6Tgj6U5YqFDbvM2CicZbbd5ofdKc5G+9f9W5D46wv8ddjyUYzyR8rVODYoR+eKpdnwEIkcEJad10K2DjmuLUGV/lOMtbYx16Ig/PXMcMbHy2T6izHbx+VEn46QIgvKYovOzIJilZJyeZYhgmThoL568tcysqzel8oEvhgg5lNgG9bcWBgUmSkKal44/vWYi7YP6lLZvjC8yJOZSd00pkaeyemL27KIRT426Dub7LjWPEA+0cLp/09HYGLUl7GKF+83yRc0tv5fLlfwOho81abmoPXlvcZ5FOR/sn25waRa12Kmr/GYRvixfpE2iyD0F6sOmm2l7El5r3o4tvUH60mPy+pFYX+VUeRSCY4k2kqgSckMUvBTHonfNHFFmqe0Bnft/3oNEgipRtwtm+skEvfZJq83QuJQySe9MVEU4iO0kxfqYC5/A0HR32+APkM0qk8X3uhD0KzLlOqakL+Gt9sYa1ePq+3ST8MKVnSiSSgW1Z48Jjpz8ejOcX6T0jz7tw/IdGJHxa0oAUtaEELWtCCFrSgBS1oQQta0IIWtKAFLWhBC1rQV6T/B+NavHGAI3EmAAAAAElFTkSuQmCC" },
                    { 5, " Feeding America is a nationwide network of food banks and food pantries working to combat hunger and food insecurity in the United States. They gather surplus food and distribute it to people in need, partnering with local communities to provide millions of meals to those struggling with hunger.", "Feeding America", "https://www.harvesters.org/wp-content/uploads/2023/09/Feeding-America-Plate.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "uid" },
                values: new object[] { 1, "email@email.com", "Madds", "123" });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "charityId", "userId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 3, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharityUser_UsersId",
                table: "CharityUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_charityId",
                table: "Subscriptions",
                column: "charityId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_userId",
                table: "Subscriptions",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharityUser");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Charities");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
