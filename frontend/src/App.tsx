import React, { useEffect, useState } from "react";
import {
  Box,
  Heading,
  Center,
  Text,
  Container,
} from "@chakra-ui/react";
import { VStack } from "@chakra-ui/layout";
import { useColorModeValue } from "@chakra-ui/color-mode";
import { Table, Thead, Tbody, Tr, Th, Td } from "@chakra-ui/table";

type Category = { id: number; name: string; description: string };
type Phrase = { id: number; chinese: string; pinyin: string; english: string; category: Category };
type Week = { id: number; startDate: string; endDate: string; phrases: Phrase[] };

function App() {
  const [weeks, setWeeks] = useState<Week[]>([]);

  useEffect(() => {
    fetch("http://localhost:5133/api/week/with-phrases")
      .then(res => res.json())
      .then(setWeeks);
  }, []);

  const tableBg = useColorModeValue("white", "gray.700");
  const tableHeaderBg = useColorModeValue("teal.400", "teal.600");
  const tableHeaderColor = useColorModeValue("white", "gray.100");
  const weekBoxBg = useColorModeValue("teal.50", "teal.900");

  return (
    <Box minH="100vh" bg={useColorModeValue("gray.100", "gray.800")} py={10}>
      <Container maxW="4xl">
        <VStack spacing={8}>
          <Heading as="h1" size="2xl" color="teal.600" mb={4} textAlign="center">
            Weekly Phrases
          </Heading>
          {weeks.map(week => (
            <Box
              key={week.id}
              w="100%"
              bg={weekBoxBg}
              boxShadow="md"
              borderRadius="lg"
              p={6}
              mb={4}
            >
              <Heading as="h2" size="md" color="teal.700" mb={4} textAlign="center">
                Week {week.id}: {week.startDate} - {week.endDate}
              </Heading>
              <Table variant="striped" colorScheme="teal" bg={tableBg} borderRadius="md" overflow="hidden">
                <Thead bg={tableHeaderBg}>
                  <Tr>
                    <Th color={tableHeaderColor}>Chinese</Th>
                    <Th color={tableHeaderColor}>Pinyin</Th>
                    <Th color={tableHeaderColor}>English</Th>
                    <Th color={tableHeaderColor}>Category</Th>
                  </Tr>
                </Thead>
                <Tbody>
                  {week.phrases.map(phrase => (
                    <Tr key={phrase.id}>
                      <Td fontWeight="bold">{phrase.chinese}</Td>
                      <Td>{phrase.pinyin}</Td>
                      <Td>{phrase.english}</Td>
                      <Td>
                        <Text color="teal.500" fontWeight="semibold">
                          {phrase.category?.name}
                        </Text>
                      </Td>
                    </Tr>
                  ))}
                </Tbody>
              </Table>
            </Box>
          ))}
        </VStack>
      </Container>
    </Box>
  );
}

export default App;
