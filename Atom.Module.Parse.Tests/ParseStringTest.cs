using System;
using System.Xml.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atom.Module.Parse.Tests
{
    [TestClass]
    public class ParseStringTest
    {
        /// <summary>
        /// Enumeration used for testing purposes.
        /// </summary>
        private enum TestEnum
        {
            Zero = 0,
            One = 1,
            Two = 2
        }

        [TestMethod]
        public void Cannot_Parse_Values_Of_Unknown_Type()
        {
            "xml".Invoking(s => s.As<XDocument>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Parsing as XDocument is not supported.");
        }

        [TestMethod]
        public void Can_Parse_String_Values()
        {
            "text".As<string>().Should().Be("text");
            String.Empty.As<string>().Should().BeEmpty();
            "   ".As<string>().Should().Be("   ");
            ((string)null).As<string>().Should().BeNull();
        }

        [TestMethod]
        public void Can_Parse_Boolean_Values()
        {
            "true".As<bool>().Should().BeTrue();
            "True".As<bool>().Should().BeTrue();
            "TRUE".As<bool>().Should().BeTrue();
            "TrUe".As<bool>().Should().BeTrue();
            "true   ".As<bool>().Should().BeTrue();

            "false".As<bool>().Should().BeFalse();
            "False".As<bool>().Should().BeFalse();
            "FALSE".As<bool>().Should().BeFalse();
            "FaLsE".As<bool>().Should().BeFalse();
            "   false".As<bool>().Should().BeFalse();

            "yes".Invoking(s => s.As<bool>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Boolean from string value 'yes'.");

            String.Empty.Invoking(s => s.As<bool>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Boolean from string value ''.");

            "   ".Invoking(s => s.As<bool>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Boolean from string value '   '.");

            ((string)null).Invoking(s => s.As<bool>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Boolean from string value ''.");
        }

        [TestMethod]
        public void Can_Parse_Boolean_Nullable_Values()
        {
            "true".As<bool?>().Should().BeTrue();
            "True".As<bool?>().Should().BeTrue();
            "TRUE".As<bool?>().Should().BeTrue();
            "TrUe".As<bool?>().Should().BeTrue();
            "true   ".As<bool?>().Should().BeTrue();

            "false".As<bool?>().Should().BeFalse();
            "False".As<bool?>().Should().BeFalse();
            "FALSE".As<bool?>().Should().BeFalse();
            "FaLsE".As<bool?>().Should().BeFalse();
            "   false".As<bool?>().Should().BeFalse();

            "yes".Invoking(s => s.As<bool?>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Nullable<Boolean> from string value 'yes'.");

            String.Empty.As<bool?>().Should().BeNull();
            "   ".As<bool?>().Should().BeNull();
            ((string)null).As<bool?>().Should().BeNull();
        }

        [TestMethod]
        public void Can_Parse_Byte_Values()
        {
            "25".As<byte>().Should().Be(25);
            "   25   ".As<byte>().Should().Be(25);

            "-38".Invoking(s => s.As<byte>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Byte from string value '-38'.");

            "1000".Invoking(s => s.As<byte>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Byte from string value '1000'.");

            "1e2".Invoking(s => s.As<byte>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Byte from string value '1e2'.");

            "NaN".Invoking(s => s.As<byte>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Byte from string value 'NaN'.");

            String.Empty.Invoking(s => s.As<byte>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Byte from string value ''.");

            "   ".Invoking(s => s.As<byte>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Byte from string value '   '.");

            ((string)null).Invoking(s => s.As<byte>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Byte from string value ''.");
        }

        [TestMethod]
        public void Can_Parse_Byte_Nullable_Values()
        {
            "25".As<byte?>().Should().Be(25);
            "   25   ".As<byte?>().Should().Be(25);

            "-38".Invoking(s => s.As<byte?>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Nullable<Byte> from string value '-38'.");

            "1000".Invoking(s => s.As<byte?>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Nullable<Byte> from string value '1000'.");

            "1e2".Invoking(s => s.As<byte>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Byte from string value '1e2'.");

            "NaN".Invoking(s => s.As<byte?>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Nullable<Byte> from string value 'NaN'.");

            String.Empty.As<byte?>().Should().BeNull();
            "   ".As<byte?>().Should().BeNull();
            ((string)null).As<byte?>().Should().BeNull();
        }

        [TestMethod]
        public void Can_Parse_Int16_Values()
        {
            "25".As<short>().Should().Be(25);
            "   25   ".As<short>().Should().Be(25);
            "-38".As<short>().Should().Be(-38);
            "1000".As<short>().Should().Be(1000);

            "100000".Invoking(s => s.As<short>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Int16 from string value '100000'.");

            "1e2".Invoking(s => s.As<short>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Int16 from string value '1e2'.");

            "NaN".Invoking(s => s.As<short>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Int16 from string value 'NaN'.");

            String.Empty.Invoking(s => s.As<short>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Int16 from string value ''.");

            "   ".Invoking(s => s.As<short>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Int16 from string value '   '.");

            ((string)null).Invoking(s => s.As<short>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Int16 from string value ''.");
        }

        [TestMethod]
        public void Can_Parse_Int16_Nullable_Values()
        {
            "25".As<short?>().Should().Be(25);
            "   25   ".As<short?>().Should().Be(25);
            "-38".As<short?>().Should().Be(-38);
            "1000".As<short?>().Should().Be(1000);

            "100000".Invoking(s => s.As<short?>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Nullable<Int16> from string value '100000'.");

            "1e2".Invoking(s => s.As<short?>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Nullable<Int16> from string value '1e2'.");

            "NaN".Invoking(s => s.As<short?>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Nullable<Int16> from string value 'NaN'.");

            String.Empty.As<short?>().Should().BeNull();
            "   ".As<short?>().Should().BeNull();
            ((string)null).As<short?>().Should().BeNull();
        }

        [TestMethod]
        public void Can_Parse_Int32_Values()
        {
            "25".As<int>().Should().Be(25);
            "   25   ".As<int>().Should().Be(25);
            "-38".As<int>().Should().Be(-38);
            "1000".As<int>().Should().Be(1000);
            "100000".As<int>().Should().Be(100000);

            "10000000000".Invoking(s => s.As<int>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Int32 from string value '10000000000'.");

            "1e2".Invoking(s => s.As<int>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Int32 from string value '1e2'.");

            "NaN".Invoking(s => s.As<int>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Int32 from string value 'NaN'.");

            String.Empty.Invoking(s => s.As<int>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Int32 from string value ''.");

            "   ".Invoking(s => s.As<int>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Int32 from string value '   '.");

            ((string)null).Invoking(s => s.As<int>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Int32 from string value ''.");
        }

        [TestMethod]
        public void Can_Parse_Int32_Nullable_Values()
        {
            "25".As<int?>().Should().Be(25);
            "   25   ".As<int?>().Should().Be(25);
            "-38".As<int?>().Should().Be(-38);
            "1000".As<int?>().Should().Be(1000);
            "100000".As<int?>().Should().Be(100000);

            "10000000000".Invoking(s => s.As<int?>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Nullable<Int32> from string value '10000000000'.");

            "1e2".Invoking(s => s.As<int?>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Nullable<Int32> from string value '1e2'.");

            "NaN".Invoking(s => s.As<int?>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Nullable<Int32> from string value 'NaN'.");

            String.Empty.As<int?>().Should().BeNull();
            "   ".As<int?>().Should().BeNull();
            ((string)null).As<int?>().Should().BeNull();
        }

        [TestMethod]
        public void Can_Parse_Int64_Values()
        {
            "25".As<long>().Should().Be(25);
            "   25   ".As<long>().Should().Be(25);
            "-38".As<long>().Should().Be(-38);
            "1000".As<long>().Should().Be(1000);
            "100000".As<long>().Should().Be(100000);
            "10000000000".As<long>().Should().Be(10000000000);

            "10000000000000000000".Invoking(s => s.As<long>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Int64 from string value '10000000000000000000'.");

            "1e2".Invoking(s => s.As<long>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Int64 from string value '1e2'.");

            "NaN".Invoking(s => s.As<long>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Int64 from string value 'NaN'.");

            String.Empty.Invoking(s => s.As<long>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Int64 from string value ''.");

            "   ".Invoking(s => s.As<long>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Int64 from string value '   '.");

            ((string)null).Invoking(s => s.As<long>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Int64 from string value ''.");
        }

        [TestMethod]
        public void Can_Parse_Int64_Nullable_Values()
        {
            "25".As<long?>().Should().Be(25);
            "   25   ".As<long?>().Should().Be(25);
            "-38".As<long?>().Should().Be(-38);
            "1000".As<long?>().Should().Be(1000);
            "100000".As<long?>().Should().Be(100000);
            "10000000000".As<long?>().Should().Be(10000000000);

            "10000000000000000000".Invoking(s => s.As<long?>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Nullable<Int64> from string value '10000000000000000000'.");

            "1e2".Invoking(s => s.As<long?>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Nullable<Int64> from string value '1e2'.");

            "NaN".Invoking(s => s.As<long?>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Nullable<Int64> from string value 'NaN'.");

            String.Empty.As<long?>().Should().BeNull();
            "   ".As<long?>().Should().BeNull();
            ((string)null).As<long?>().Should().BeNull();
        }

        [TestMethod]
        public void Can_Parse_Single_Values()
        {
            "2.5".As<float>().Should().Be(2.5f);
            "   2.5   ".As<float>().Should().Be(2.5f);
            "-0.2".As<float>().Should().Be(-0.2f);
            "-.2".As<float>().Should().Be(-0.2f);
            "1000".As<float>().Should().Be(1000f);
            "3.4e-12".As<float>().Should().Be(3.4e-12f);

            "0".As<float>().Should().Be(0f);
            "+0".As<float>().Should().Be(0f);
            "-0".As<float>().Should().Be(0f);

            "NaN".As<float>().Should().Be(Single.NaN);
            "-Infinity".As<float>().Should().Be(Single.NegativeInfinity);
            "Infinity".As<float>().Should().Be(Single.PositiveInfinity);

            "+Infinity".Invoking(s => s.As<float>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Single from string value '+Infinity'.");

            "2,5".Invoking(s => s.As<float>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Single from string value '2,5'.");

            "1e39".Invoking(s => s.As<float>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Single from string value '1e39'.");

            String.Empty.Invoking(s => s.As<float>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Single from string value ''.");

            "   ".Invoking(s => s.As<float>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Single from string value '   '.");

            ((string)null).Invoking(s => s.As<float>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Single from string value ''.");
        }

        [TestMethod]
        public void Can_Parse_Single_Nullable_Values()
        {
            "2.5".As<float?>().Should().Be(2.5f);
            "   2.5   ".As<float?>().Should().Be(2.5f);
            "-0.2".As<float?>().Should().Be(-0.2f);
            "-.2".As<float?>().Should().Be(-0.2f);
            "1000".As<float?>().Should().Be(1000f);
            "3.4e-12".As<float?>().Should().Be(3.4e-12f);

            "0".As<float?>().Should().Be(0f);
            "+0".As<float?>().Should().Be(0f);
            "-0".As<float?>().Should().Be(0f);

            "NaN".As<float?>().Should().Be(Single.NaN);
            "-Infinity".As<float?>().Should().Be(Single.NegativeInfinity);
            "Infinity".As<float?>().Should().Be(Single.PositiveInfinity);

            "+Infinity".Invoking(s => s.As<float?>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Nullable<Single> from string value '+Infinity'.");

            "2,5".Invoking(s => s.As<float?>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Nullable<Single> from string value '2,5'.");

            "1e39".Invoking(s => s.As<float?>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Nullable<Single> from string value '1e39'.");

            String.Empty.As<float?>().Should().BeNull();
            "   ".As<float?>().Should().BeNull();
            ((string)null).As<float?>().Should().BeNull();
        }

        [TestMethod]
        public void Can_Parse_Double_Values()
        {
            "2.5".As<double>().Should().Be(2.5d);
            "   2.5   ".As<double>().Should().Be(2.5d);
            "-0.2".As<double>().Should().Be(-0.2d);
            "-.2".As<double>().Should().Be(-0.2d);
            "1000".As<double>().Should().Be(1000d);
            "3.4e-12".As<double>().Should().Be(3.4e-12d);
            "1e39".As<double>().Should().Be(1e39d);
            "0.12345678901234567890".As<double>().Should().Be(0.12345678901234568d);

            "0".As<double>().Should().Be(0d);
            "+0".As<double>().Should().Be(0d);
            "-0".As<double>().Should().Be(0d);

            "NaN".As<double>().Should().Be(Double.NaN);
            "-Infinity".As<double>().Should().Be(Double.NegativeInfinity);
            "Infinity".As<double>().Should().Be(Double.PositiveInfinity);

            "+Infinity".Invoking(s => s.As<double>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Double from string value '+Infinity'.");

            "2,5".Invoking(s => s.As<double>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Double from string value '2,5'.");

            "1e309".Invoking(s => s.As<double>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Double from string value '1e309'.");

            String.Empty.Invoking(s => s.As<double>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Double from string value ''.");

            "   ".Invoking(s => s.As<double>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Double from string value '   '.");

            ((string)null).Invoking(s => s.As<double>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Double from string value ''.");
        }

        [TestMethod]
        public void Can_Parse_Double_Nullable_Values()
        {
            "2.5".As<double?>().Should().Be(2.5d);
            "   2.5   ".As<double?>().Should().Be(2.5d);
            "-0.2".As<double?>().Should().Be(-0.2d);
            "-.2".As<double?>().Should().Be(-0.2d);
            "1000".As<double?>().Should().Be(1000d);
            "3.4e-12".As<double?>().Should().Be(3.4e-12d);
            "1e39".As<double?>().Should().Be(1e39d);

            "0".As<double?>().Should().Be(0d);
            "+0".As<double?>().Should().Be(0d);
            "-0".As<double?>().Should().Be(0d);

            "NaN".As<double?>().Should().Be(Double.NaN);
            "-Infinity".As<double?>().Should().Be(Double.NegativeInfinity);
            "Infinity".As<double?>().Should().Be(Double.PositiveInfinity);

            "+Infinity".Invoking(s => s.As<double?>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Nullable<Double> from string value '+Infinity'.");

            "2,5".Invoking(s => s.As<double?>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Nullable<Double> from string value '2,5'.");

            "1e309".Invoking(s => s.As<double?>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Nullable<Double> from string value '1e309'.");

            String.Empty.As<double?>().Should().BeNull();
            "   ".As<double?>().Should().BeNull();
            ((string)null).As<double?>().Should().BeNull();
        }

        [TestMethod]
        public void Can_Parse_Decimal_Values()
        {
            "2.5".As<decimal>().Should().Be(2.5m);
            "   2.5   ".As<decimal>().Should().Be(2.5m);
            "-0.2".As<decimal>().Should().Be(-0.2m);
            "-.2".As<decimal>().Should().Be(-0.2m);
            "1000".As<decimal>().Should().Be(1000m);
            "3.4e-12".As<decimal>().Should().Be(3.4e-12m);
            "0.12345678901234567890".As<decimal>().Should().Be(0.12345678901234567890m);

            "0".As<decimal>().Should().Be(0m);
            "+0".As<decimal>().Should().Be(0m);
            "-0".As<decimal>().Should().Be(0m);

            "NaN".Invoking(s => s.As<decimal>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Decimal from string value 'NaN'.");

            "Infinity".Invoking(s => s.As<decimal>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Decimal from string value 'Infinity'.");

            "2,5".Invoking(s => s.As<decimal>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Decimal from string value '2,5'.");

            "100000000000000000000000000000".Invoking(s => s.As<decimal>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Decimal from string value '100000000000000000000000000000'.");

            String.Empty.Invoking(s => s.As<decimal>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Decimal from string value ''.");

            "   ".Invoking(s => s.As<decimal>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Decimal from string value '   '.");

            ((string)null).Invoking(s => s.As<decimal>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Decimal from string value ''.");
        }

        [TestMethod]
        public void Can_Parse_Decimal_Nullable_Values()
        {
            "2.5".As<decimal?>().Should().Be(2.5m);
            "   2.5   ".As<decimal?>().Should().Be(2.5m);
            "-0.2".As<decimal?>().Should().Be(-0.2m);
            "-.2".As<decimal?>().Should().Be(-0.2m);
            "1000".As<decimal?>().Should().Be(1000m);
            "3.4e-12".As<decimal?>().Should().Be(3.4e-12m);
            "0.12345678901234567890".As<decimal?>().Should().Be(0.12345678901234567890m);

            "0".As<decimal?>().Should().Be(0m);
            "+0".As<decimal?>().Should().Be(0m);
            "-0".As<decimal?>().Should().Be(0m);

            "NaN".Invoking(s => s.As<decimal?>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Nullable<Decimal> from string value 'NaN'.");

            "Infinity".Invoking(s => s.As<decimal?>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Nullable<Decimal> from string value 'Infinity'.");

            "2,5".Invoking(s => s.As<decimal?>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Nullable<Decimal> from string value '2,5'.");

            "100000000000000000000000000000".Invoking(s => s.As<decimal?>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Nullable<Decimal> from string value '100000000000000000000000000000'.");

            String.Empty.As<decimal?>().Should().BeNull();
            "   ".As<decimal?>().Should().BeNull();
            ((string)null).As<decimal?>().Should().BeNull();
        }

        [TestMethod]
        public void Can_Parse_TimeSpan_Values()
        {
            "15:20:57".As<TimeSpan>().Should().Be(TimeSpan.Parse("15:20:57"));
            "   15:20:57   ".As<TimeSpan>().Should().Be(TimeSpan.Parse("15:20:57"));
            "15:20:57.123".As<TimeSpan>().Should().Be(TimeSpan.Parse("15:20:57.123"));
            "39:20:57".As<TimeSpan>().Should().Be(TimeSpan.Parse("39:20:57"));
            "1:15:20:57".As<TimeSpan>().Should().Be(TimeSpan.Parse("1:15:20:57"));

            "unknown".Invoking(s => s.As<TimeSpan>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse TimeSpan from string value 'unknown'.");

            String.Empty.Invoking(s => s.As<TimeSpan>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse TimeSpan from string value ''.");

            "   ".Invoking(s => s.As<TimeSpan>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse TimeSpan from string value '   '.");

            ((string)null).Invoking(s => s.As<TimeSpan>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse TimeSpan from string value ''.");
        }

        [TestMethod]
        public void Can_Parse_TimeSpan_Nullable_Values()
        {
            "15:20:57".As<TimeSpan?>().Should().Be(TimeSpan.Parse("15:20:57"));
            "   15:20:57   ".As<TimeSpan?>().Should().Be(TimeSpan.Parse("15:20:57"));
            "15:20:57.123".As<TimeSpan?>().Should().Be(TimeSpan.Parse("15:20:57.123"));
            "39:20:57".As<TimeSpan?>().Should().Be(TimeSpan.Parse("39:20:57"));
            "1:15:20:57".As<TimeSpan?>().Should().Be(TimeSpan.Parse("1:15:20:57"));

            "unknown".Invoking(s => s.As<TimeSpan?>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Nullable<TimeSpan> from string value 'unknown'.");

            String.Empty.As<TimeSpan?>().Should().BeNull();
            "   ".As<TimeSpan?>().Should().BeNull();
            ((string)null).As<TimeSpan?>().Should().BeNull();
        }

        [TestMethod]
        public void Can_Parse_DateTime_Values()
        {
            "1983-05-25".As<DateTime>().Should().Be(new DateTime(1983, 05, 25));
            "   1983-05-25   ".As<DateTime>().Should().Be(new DateTime(1983, 05, 25));
            "2000-11-21 15:20:57".As<DateTime>().Should().Be(new DateTime(2000, 11, 21, 15, 20, 57));
            "2000/11/21 15:20:57".As<DateTime>().Should().Be(new DateTime(2000, 11, 21, 15, 20, 57));

            "unknown".Invoking(s => s.As<DateTime>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse DateTime from string value 'unknown'.");

            String.Empty.Invoking(s => s.As<DateTime>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse DateTime from string value ''.");

            "   ".Invoking(s => s.As<DateTime>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse DateTime from string value '   '.");

            ((string)null).Invoking(s => s.As<DateTime>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse DateTime from string value ''.");
        }

        [TestMethod]
        public void Can_Parse_DateTime_Nullable_Values()
        {
            "1983-05-25".As<DateTime?>().Should().Be(new DateTime(1983, 05, 25));
            "   1983-05-25   ".As<DateTime?>().Should().Be(new DateTime(1983, 05, 25));
            "2000-11-21 15:20:57".As<DateTime?>().Should().Be(new DateTime(2000, 11, 21, 15, 20, 57));
            "2000/11/21 15:20:57".As<DateTime?>().Should().Be(new DateTime(2000, 11, 21, 15, 20, 57));

            "unknown".Invoking(s => s.As<DateTime?>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Nullable<DateTime> from string value 'unknown'.");

            String.Empty.As<DateTime?>().Should().BeNull();
            "   ".As<DateTime?>().Should().BeNull();
            ((string)null).As<DateTime?>().Should().BeNull();
        }

        [TestMethod]
        public void Can_Parse_Guid_Values()
        {
            var id = new Guid("2DC0B86E-3E16-445A-88B8-C39EFF611331");
            "{2DC0B86E-3E16-445A-88B8-C39EFF611331}".As<Guid>().Should().Be(id);
            "   {2DC0B86E-3E16-445A-88B8-C39EFF611331}   ".As<Guid>().Should().Be(id);
            "2DC0B86E-3E16-445A-88B8-C39EFF611331".As<Guid>().Should().Be(id);
            "2dc0b86e-3e16-445a-88b8-c39eff611331".As<Guid>().Should().Be(id);
            "2dc0b86e3e16445a88b8c39eff611331".As<Guid>().Should().Be(id);

            "unknown".Invoking(s => s.As<Guid>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Guid from string value 'unknown'.");

            String.Empty.Invoking(s => s.As<Guid>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Guid from string value ''.");

            "   ".Invoking(s => s.As<Guid>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Guid from string value '   '.");

            ((string)null).Invoking(s => s.As<Guid>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Guid from string value ''.");
        }

        [TestMethod]
        public void Can_Parse_Guid_Nullable_Values()
        {
            var id = new Guid("2DC0B86E-3E16-445A-88B8-C39EFF611331");
            "{2DC0B86E-3E16-445A-88B8-C39EFF611331}".As<Guid>().Should().Be(id);
            "   {2DC0B86E-3E16-445A-88B8-C39EFF611331}   ".As<Guid>().Should().Be(id);
            "2DC0B86E-3E16-445A-88B8-C39EFF611331".As<Guid>().Should().Be(id);
            "2dc0b86e-3e16-445a-88b8-c39eff611331".As<Guid>().Should().Be(id);
            "2dc0b86e3e16445a88b8c39eff611331".As<Guid>().Should().Be(id);

            "unknown".Invoking(s => s.As<Guid?>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse Nullable<Guid> from string value 'unknown'.");

            String.Empty.As<Guid?>().Should().BeNull();
            "   ".As<Guid?>().Should().BeNull();
            ((string)null).As<Guid?>().Should().BeNull();
        }

        [TestMethod]
        public void Can_Parse_Enum_Values()
        {
            "Zero".As<TestEnum>().Should().Be(TestEnum.Zero);
            "   Zero   ".As<TestEnum>().Should().Be(TestEnum.Zero);
            "one".As<TestEnum>().Should().Be(TestEnum.One);
            "TWO".As<TestEnum>().Should().Be(TestEnum.Two);

            "0".As<TestEnum>().Should().Be(TestEnum.Zero);
            "1".As<TestEnum>().Should().Be(TestEnum.One);
            "2".As<TestEnum>().Should().Be(TestEnum.Two);

            "3".As<TestEnum>().Should().NotBe(TestEnum.Zero)
                .And.Should().NotBe(TestEnum.One)
                .And.Should().NotBe(TestEnum.Two);

            "unknown".Invoking(s => s.As<TestEnum>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse TestEnum from string value 'unknown'.");

            String.Empty.Invoking(s => s.As<TestEnum>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse TestEnum from string value ''.");

            "   ".Invoking(s => s.As<TestEnum>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse TestEnum from string value '   '.");

            ((string)null).Invoking(s => s.As<TestEnum>())
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Cannot parse TestEnum from string value ''.");
        }

        [TestMethod]
        public void Can_Parse_Enum_Nullable_Values()
        {
            "Zero".As<TestEnum?>().Should().Be(TestEnum.Zero);
            "   Zero   ".As<TestEnum?>().Should().Be(TestEnum.Zero);
            "one".As<TestEnum?>().Should().Be(TestEnum.One);
            "TWO".As<TestEnum?>().Should().Be(TestEnum.Two);

            "0".As<TestEnum?>().Should().Be(TestEnum.Zero);
            "1".As<TestEnum?>().Should().Be(TestEnum.One);
            "2".As<TestEnum?>().Should().Be(TestEnum.Two);

            "3".As<TestEnum?>().Should().NotBe(TestEnum.Zero)
                .And.Should().NotBe(TestEnum.One)
                .And.Should().NotBe(TestEnum.Two);

            String.Empty.As<TestEnum?>().Should().BeNull();
            "   ".As<TestEnum?>().Should().BeNull();
            ((string)null).As<TestEnum?>().Should().BeNull();
        }
    }
}
