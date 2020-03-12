using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Book.UnitTestProjects
{
    [TestClass]
    public class BogTests
    {
        [TestMethod]
        [ExpectedException(typeof(ManglendeTitelException))]
        public void Bog_ConstructedUsingInvalidTitle_ThrowsManglendeTitelException()
        {
            // Arrange
            string invalidTitle = ""; // Empty title
            string validAuthor = "Hans Hansen";
            int validPageNumber = 10;
            string validIsbn13 = "0001234567890";

            // Act and assert
            var result = new Bog(invalidTitle, validAuthor, validPageNumber, validIsbn13);
        }

        [TestMethod]
        public void Bog_ConstructedUsingInvalidTitle_ThrowsManglendeTitelException_2()
        {
            // Arrange
            string invalidTitle = ""; // Empty title
            string validAuthor = "Hans Hansen";
            int validPageNumber = 10;
            string validIsbn13 = "0001234567890";

            // Act and assert
            Assert.ThrowsException<ManglendeTitelException>(() =>
                new Bog(invalidTitle, validAuthor, validPageNumber, validIsbn13));
        }

        [TestMethod]
        public void Bog_ConstructedUsingInvalidAuthor_ThrowsForfatterForKortException()
        {
            // Arrange
            string validTitle = "Min bog";
            string invalidAuthor = "H"; // Less than two characters
            int validPageNumber = 10;
            string validIsbn13 = "0001234567890";

            // Act and assert
            Assert.ThrowsException<ForfatterForKortException>(() =>
                new Bog(validTitle, invalidAuthor, validPageNumber, validIsbn13));
        }
        
        [TestMethod]
        public void Bog_ConstructedUsingInvalidPageNumber_ThrowsUgyldigtSidetalException()
        {
            // Arrange
            string validTitle = "Min bog";
            string validAuthor = "Hans Hansen";
            int invalidPageNumber = -1; // Invalid page number 
            string validIsbn13 = "0001234567890";

            // Act and assert
            Assert.ThrowsException<UgyldigtSidetalException>(() =>
                new Bog(validTitle, validAuthor, invalidPageNumber, validIsbn13));
        }

        [TestMethod]
        public void Bog_ConstructedUsingInvalidIsbn13_ThrowsUgyldigtIsbnException()
        {
            // Arrange
            string validTitle = "Min bog";
            string validAuthor = "Hans Hansen";
            int validPageNumber = 10;
            string invalidIsbn13 = "12345678910111213"; // Invalid ISBN13

            // Act and assert
            Assert.ThrowsException<UgyldigtIsbnException>(() =>
                new Bog(validTitle, validAuthor, validPageNumber, invalidIsbn13));
        }

        [TestMethod]
        public void Bog_ConstructedUsingValidArgs_CreatesNewBogInstance()
        {
            // Arrange
            string validTitle = "Min bog";
            string validAuthor = "Hans Hansen";
            int validPageNumber = 10;
            string validIsbn13 = "0001234567890";

            // Act
            var result = new Bog(validTitle, validAuthor, validPageNumber, validIsbn13);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Bog));
        }
    }
}
